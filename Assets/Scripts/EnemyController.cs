using UnityEngine;
using System.Collections;

public class EnemyController : Enemy {
 
    int currentHp;
    int hp = 5;
    bool isBurning;
    SpriteRenderer spriteRend;

    void Start()
    {
        currentHp = hp;
        spriteRend = GetComponent<SpriteRenderer>();
    }

    void Update ()
    {
        Lerp();
    }
    
    void Lerp ()
    {
        float y =  startPosition.y;
        float z = startPosition.z;
        float x = 2 * Mathf.Sin(Time.timeSinceLevelLoad) + startPosition.x;
        transform.Translate(x * Time.deltaTime, y, z);
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        if(c.gameObject.tag == "Fire")
        {
            isBurning = true;
            Burn(spriteRend);
            transform.Translate(100* Time.deltaTime, startPosition.y, startPosition.z);
        }

        if (c.gameObject.tag == "Attack")
        {
            SumScore.Add(100);
            hp = hp - 1;
            Debug.Log(hp);
            if (hp <= 0)
            {
                Destroy(this.gameObject);
                Explosion();
            }

            //Step back "logic" while get hitted
            transform.Translate(-10 * Time.deltaTime, startPosition.y, startPosition.z);
        }
    }
}
