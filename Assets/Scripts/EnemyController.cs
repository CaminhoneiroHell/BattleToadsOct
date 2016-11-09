using UnityEngine;
using System.Collections;

public enum EnemyType
{
    inofencive,
    agressive
}

public class EnemyController : Enemy {
 
    int currentHp;
    int hp = 5;
    bool isBurning;
    Animator anim_enemy;
    SpriteRenderer spriteRend;
    public EnemyType enemyType;

    void Start()
    {
        currentHp = hp;
        anim_enemy = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        HandleEnemyType();
    }

    void HandleEnemyType()
    {
        switch(enemyType)
        {
            case EnemyType.agressive:
                Lerp();
                break;
            case EnemyType.inofencive:
                hp = 1;
                Walk();
                break;
        }
    }
    
    void Lerp ()
    {
        float y =  startPosition.y;
        float z = startPosition.z;
        float x = 2 * Mathf.Sin(Time.timeSinceLevelLoad) + startPosition.x;
        transform.Translate(x * Time.deltaTime, y, z);
    }

    void Walk()
    {
        float y = startPosition.y;
        float z = startPosition.z;
        transform.Translate(-2 * Time.deltaTime, y, z);
    }

    void Die()
    {
        anim_enemy.SetTrigger("Die");
    }

    private void OnTriggerEnter2D(Collider2D c)
    {

        //if (c.gameObject.tag == "Fire")
        //{
        //    if (anim_enemy != null)
        //    {
        //        anim_enemy.SetTrigger("Die");
        //    }
        //    isBurning = true;
        //    Burn(spriteRend);
        //    transform.Translate(100* Time.deltaTime, startPosition.y, startPosition.z);
        //}

        if (c.gameObject.tag == "Attack")
        {
            SumScore.Add(100);
            hp = hp - 1;
            Debug.Log(hp);
            if (hp <= 0)
            {
                if(anim_enemy != null)
                {
                    anim_enemy.SetTrigger("Die");
                    Destroy(this.gameObject, 3f);
                }
                else
                {
                    Explosion();
                    Destroy(this.gameObject, 3f);
                }
            }

            //Step back "logic" while get hitted
            //transform.Translate(-10 * Time.deltaTime, startPosition.y, startPosition.z);
        }
    }
}
