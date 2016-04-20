using UnityEngine;
using System.Collections;

public class EnemyController : NinjaController {

    public GameObject[] enemyType;
    public GameObject myCreator;

    void FixedUpdate()
    {
        int direction = facingRight ? 1 : -1;
        Move(0.5f * direction);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        print(other.name);
        if (other.name == "Ninja")
        {
            if (other.transform.position.x < transform.position.x && facingRight)
            {
                StartFlip();
            }
        }
        else if (other.name == "Fuuma_Shuriken 1(Clone)") {
            StartHurt();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        print(other.name);
        if (other.name == "Ninja")
        {
            StartFlip();
        }
    }

    public override void StartHurt()
    {
        hitPoints--;
        if (hitPoints <= 0)
        {
            animator.SetTrigger("startDie");
            NinjaSpawnController SpawnController = myCreator.GetComponent<NinjaSpawnController>();
            SpawnController.killEnemy();
        }
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Ninja Die"))
        {
            animator.SetTrigger("startHurt");
        }

    }

}
