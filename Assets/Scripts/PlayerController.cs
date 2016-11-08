using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    #region Variables

    public Animator anim_player;
    public GameObject kick;
    public GameObject bike;
    public GameObject flame;
    public Transform playerT;
    private Transform flameT;

    public bool attack;
    bool isMoving;
    bool bikeChecker;
    bool facing_Right = true;

    float player_speed = 3f;
    float player_boost = 0.1f;

    Rigidbody2D player_body;
    SpriteRenderer spriteRend;

    //Jump Business
    private Transform groundCheck;
    private bool grounded = false;
    bool jump;
    float jumpSpeed = 10;
    float jumpForce = 10;

    #endregion

    void Awake()
    {
        groundCheck = transform.Find("groundCheck");
        spriteRend = GetComponent<SpriteRenderer>();
        anim_player = GetComponent<Animator>();
        player_body = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        anim_player.SetBool("Idle", true);
        flameT = flame.transform;
    }

    #region FlameBikeController

    void IncreaseFlame()
    {
        flameT = flame.transform;
        Vector2 scale = gameObject.transform.localScale;
        scale.x = Random.Range(0.6f, 1f);
        scale.y = Random.Range(0.3f, 0.3f);
        flameT.localScale = scale;
    }
    #endregion

    void Update()
    {

        PlayerMover();
        PlayerInput();

        //Verificar bool para checar se o player está no chão ou no ar.
        //print(grounded);

        grounded = Physics2D.Linecast(transform.position,
            groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }

        if (jump)
        {
            // Set the Jump animator trigger parameter.
            anim_player.SetTrigger("JumpBike");

            // Add a vertical force to the player.
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));

            // Make sure the player can't jump again until the jump conditions from Update are satisfied.
            jump = false;
        }



        if (Input.GetKeyDown(KeyCode.X))
        {
            
        }
    }

    #region MoveBusiness
    public void Move(Vector2 direction)
    {
        GetComponent<Rigidbody2D>().velocity = direction * player_speed;
    }

    public void PlayerMover()
    {
        #region Comandos movimento
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        //if (Input.GetAxis("Horizontal") > 0)
            Move(new Vector2(x, y).normalized);

        if (bikeChecker)
        {
            if (x > 0 && !facing_Right)
                Flip();
            else if (x < 0 && facing_Right)
                Flip();
        }
        #endregion

        #region Limita x e y

        //x
        //if (transform.position.x <= 9f)
        //    transform.position = new Vector3(9f, transform.position.y, transform.position.z);
        //else if (transform.position.x >= 12f)
        //    transform.position = new Vector3(12f, transform.position.y, transform.position.z);

        //y
        //if (transform.position.y <= -0.51f)
        //    transform.position = new Vector3(transform.position.x, -0.51f, transform.position.z);
        //else if (transform.position.y >= -0.01f)
        //    transform.position = new Vector3(transform.position.x, -0.01f, transform.position.z);


        #endregion

        //if (Input.GetButtonDown("Jump"))
        //{
        //    anim_player.SetTrigger("JumpBike");
        //    player_body.gravityScale = -2f;

            //float minimum = 10.0F;
            //float maximum = 20.0F;
            //transform.position = new Vector3(0, Mathf.Lerp(minimum, maximum, Time.time), 0);


            //float min = -0.51f;
            //float max = 0.1f;
            //transform.position = new Vector3(transform.position.x, Mathf.Lerp(min, max, Time.time), 0);
        //}
    }

    void Flip()
    {
        facing_Right = !facing_Right;
        Vector3 theScale = spriteRend.transform.localScale;
        theScale.x *= -1;
        spriteRend.transform.localScale = theScale;
    }

    #endregion

    #region CharacterStateBusiness

    //Control idle state
    void Ride()
    {
        this.gameObject.tag = "Player";
        attack = false;
    }

    public void BoostFront()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(player_boost, 0));
        //this.gameObject.tag = "Attack";
        anim_player.SetTrigger("BoostBike");
        attack = true;
    }

    public void KickBack()
    {
        //this.gameObject.tag = "Attack";
        anim_player.SetTrigger("KickBike");
        kick.SetActive(true);
        attack = true;
    }

    public void SpecialAttack()
    {
        attack = true;
        this.gameObject.tag = "Attack";
        anim_player.SetTrigger("SpecialAttack");
    }

    public void ThrowBikeAway(Transform origin)
    {
        Instantiate(bike, origin.position, origin.rotation);
        bike.GetComponent<Rigidbody2D>().velocity = transform.right.normalized * -100f;
        flame.SetActive(false);
    }

    #endregion
    
    #region InputBusiness
    void PlayerInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //JumpMethodHere
        }
        if (Input.GetMouseButtonDown(0))
        {

            BoostFront();
        }
        if (Input.GetMouseButtonDown(1))
        {

            KickBack();
        }
        if(!Input.GetMouseButtonDown(0) && !Input.GetMouseButtonDown(1))
        {
            Ride();
        }

    }
    #endregion

    #region CollisionController

    /*FastTags
    Ground
    Obstacle
    Enemy
    Item
    Attack
    */

    //#region Score methods
    //public void CheckHighScore()
    //{
    //    if (SumScore.Score > SumScore.HighScore)
    //        SumScore.SaveHighScore();
    //}
    
    //public void AddPoints(int points)
    //{
    //    SumScore.Add(points);
    //}
    //#endregion

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Obstacle")
        {
          //  anim_player.SetBool("IdleBike", false);
            //anim_player.SetTrigger("DieBike");
            flame.SetActive(false);
        }

        if(c.tag == "Enemy" && !kick)
        {
            anim_player.SetTrigger("DieBike");
        }

        if (c.tag == "Enemy" && kick)
        {
            Debug.Log("Dei porrada");
        }

        //if (c.tag == "Enemy" && this.gameObject.tag == "Attack")
        //{
        //    SumScore.Add(100);
        //    Destroy(c.gameObject);
        //}

        if (c.tag == "Item")
        {
            SumScore.Add(100);
            Destroy(c.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D c)
    {
        //if (c.gameObject.tag == "Ground" && (Input.GetKey(KeyCode.W)))
        //{
        //    GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpSpeed);
        //}
    }

    private void OnTriggerExit2D(Collider2D c)
    {
        if (c.tag == "")
        {

        }
    }

    #endregion
}