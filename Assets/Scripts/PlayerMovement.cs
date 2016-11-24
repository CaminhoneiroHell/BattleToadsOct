using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    bool canAttack;
    Transform myT;

    [SerializeField]
    Animator anim;
    
    [SerializeField]
    Vector3 startPosition;

    [SerializeField]
    GameObject fire;

    [SerializeField]
    float movementSpeed = 5f;

    [SerializeField]
    float attackOnTime = .5f;
    
    [SerializeField]
    float attackDelay = .5f;


    void Awake()
    {
        myT = transform;
    }

    void Start()
    {
        canAttack = true;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Thrust();
        if(Input.GetMouseButton(0))
            Boost();
        if (Input.GetMouseButton(1))
            Kick();
    }

    #region Movimentos
    void Thrust()
    {
        if (Input.GetAxis("Horizontal") > 0)
            transform.position += transform.right * movementSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        if (Input.GetAxis("Horizontal") < 0)
            transform.position -= transform.right * -movementSpeed * Time.deltaTime * Input.GetAxis("Horizontal");

        if (Input.GetAxis("Vertical") > 0)
            transform.position += transform.up * movementSpeed * Time.deltaTime * Input.GetAxis("Vertical");
        if (Input.GetAxis("Vertical") < 0)
            transform.position -= transform.up * -movementSpeed * Time.deltaTime * Input.GetAxis("Vertical");
    }
    #endregion

    #region Ataques

    void Boost()
    {
        if(canAttack)
        {
            gameObject.tag = "Attack";
            anim.SetTrigger("BoostBike");
            fire.SetActive(false);
            Invoke("TurnOffAttack", attackOnTime);
            Invoke("CanAttack", attackDelay);
            canAttack = false;
        }
    }


    void Kick()
    {
        if (canAttack)
        {
            gameObject.tag = "Attack";
            anim.SetTrigger("KickBike");
            fire.SetActive(false);
            Invoke("TurnOffAttack", attackOnTime);
            Invoke("CanAttack", attackDelay);
            canAttack = false;
        }
    }

    void SpecialAttack()
    {
        if (canAttack)
        {
            gameObject.tag = "Attack";
            anim.SetTrigger("SpecialAttack");
            fire.SetActive(false);
            Invoke("TurnOffAttack", attackOnTime);
            Invoke("CanAttack", attackDelay);
            canAttack = false;
        }
    }

    void TurnOffAttack()
    {
        gameObject.tag = "Player";
        fire.SetActive(true);
        canAttack = true;
        anim.SetTrigger("Idle");
    }

    void CanAttack()
    {
        canAttack = true;
    }

    //Vector3 CastRay()
    //{
    //    f
    //    RaycastHit hit;
    //    Vector3 fwd = transform.TransformDirection(Vector3.forward) * maxDistance;

    //    if (Physics.Raycast(transform.position, fwd, out hit))
    //    {
    //        Debug.Log("We hit: " + hit.transform.name);

    //        Explosion temp = hit.transform.GetComponent<Explosion>();

    //        SpawnExplosion(hit.point, hit.transform);

    //        return hit.point;
    //    }
    //    Debug.Log("We missed...");
    //    return transform.position + (transform.forward * maxDistance);
    //}

    #endregion

    #region Colisão
    
   //Pega local de colisão, alvo, e distribui dano
    void SpawnExplosion(Vector3 hitPosition, Transform target, int damage)
    {
        Explosion temp = target.GetComponent<Explosion>();
        if (temp != null)
            temp.IveBeenHit(hitPosition, damage);

    }


    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Enemy")
        {
            Camera.main.GetComponent<CameraController>().PlayShake();
            SpawnExplosion(c.transform.position, gameObject.transform, 1);
            //SpawnImpulse(c.transform.position, c.transform);
            Debug.Log("Sentiu");
        }

        if (c.tag == "Obstacle")
        {
            SpawnExplosion(c.transform.position, gameObject.transform, 2);
            //SpawnImpulse(c.transform.position, c.transform);
            Debug.Log("Sentiu");
        }
    }

    #endregion

}
