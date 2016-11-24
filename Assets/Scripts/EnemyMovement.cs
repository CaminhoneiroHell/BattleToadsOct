using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
    [SerializeField]
    Transform target;

    [SerializeField]
    Animator anim;

    [SerializeField]
    bool canMove;

    void Update ()
    {
        if (!FindTarget())
            return;
        else
        {
            Move();
        }
    }

    #region Movimentos
    void Move()
    {
        Vector3 pos = target.position - transform.position;
        transform.position += pos * Time.deltaTime;
    }

    bool FindTarget()
    {
        if (target == null)
        {
            GameObject temp = GameObject.FindGameObjectWithTag("Player");

            if (temp != null)
                target = temp.transform;
        }

        if (target == null)
            return false;

        return true;
    }
    #endregion

    #region Colisão

    void SpawnExplosion(Vector3 hitPosition, Transform target, int damage)
    {
        Explosion temp = target.GetComponent<Explosion>();
        if (temp != null)
            temp.IveBeenHit(hitPosition, damage);
    }


    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Attack")
        {
            Debug.Log("Sentiu");
            anim.SetTrigger("TakeHit");
            SpawnExplosion(this.gameObject.transform.position, gameObject.transform, 3);
            //this.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * -0.011f * Time.timeScale, ForceMode2D.Force);
        }

        //if (c.tag == "Obstacle")
        //{
        //    SpawnExplosion(c.transform.position, gameObject.transform, 2);
        //    //SpawnImpulse(c.transform.position, c.transform);
        //    Debug.Log("Sentiu");
        //}
    }

    private void OnTriggerExit2D(Collider2D c)
    {
        anim.SetTrigger("Move");
    }

    #endregion
}
