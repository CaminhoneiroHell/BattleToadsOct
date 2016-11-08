using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public float speed;
    public float shotDelay;
    public bool canShot;
    public Vector3 startPosition;
    
    public GameObject bullet;
    public GameObject explosion;
    public GameObject burning;
    
    public void Explosion()
    {
        Instantiate(explosion, transform.position, transform.rotation);
    }

    public void Shot(Transform origin)
    {
        Instantiate(bullet, origin.position, origin.rotation);
    }

    public void Move(Vector2 direction)
    {
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

    public void Burn(SpriteRenderer spriteRend)
    {
        burning.SetActive(true);
        spriteRend.color = new Vector4(0, 0, 0, 1);
        gameObject.GetComponent<Collider2D>().enabled = false;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 3f;
    }

}
