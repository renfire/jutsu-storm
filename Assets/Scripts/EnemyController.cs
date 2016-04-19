using UnityEngine;
using System.Collections;

public class EnemyController : NinjaController {

    public GameObject[] enemyType;

    void Start()
    {
        Move(0.5f);
    }

    void FixedUpdate()
    {
        int direction = facingRight ? 1 : -1;
        if (currentNinjaState == NinjaStates.WALKING) Move(0.5f * direction);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Ninja")
        {
            if (other.transform.position.x < transform.position.x && facingRight && currentNinjaState != NinjaStates.FLIPPING)
            {
                StartFlip();
            }
        }
        else if (other.name == "Fuuma_Shuriken 1(Clone)") {
            animator.SetTrigger("startDie");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Ninja")
        {
            if (!facingRight) StartFlip();
            else StartWait();
        }
    }
}
