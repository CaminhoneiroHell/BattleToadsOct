using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour
{
    [SerializeField]
    GameObject explosion;
    [SerializeField]
    GameObject blowUp;
    [SerializeField]
    Rigidbody2D rigidBody;
    [SerializeField]
    PlayerLife life;

    public void IveBeenHit(Vector2 pos, int dmg)
    {
        GameObject go = Instantiate(explosion, pos, Quaternion.identity, transform) as GameObject;
        Destroy(go, 6f);

        if (life == null)
            return;

        Debug.Log("Taking dmg");
        life.TakeDamage(dmg);
    }
    
    public void BlowUp()
    {
        //SummonParticleEffect
        Instantiate(blowUp, transform.position, Quaternion.identity);

        //destroyitself
        Destroy(gameObject);

    }
}
