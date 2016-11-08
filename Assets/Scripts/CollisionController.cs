using UnityEngine;
using System.Collections;

public class CollisionController : MonoBehaviour {

    Animator anim_player;

    void Start()
    {
        anim_player = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
    }

    private void OnTriggerStay2D(Collider2D c)
    {
    }
    
    private void OnTriggerExit2D(Collider2D c)
    {
    }
}
