using UnityEngine;
using System.Collections;

public class NinjaController : MonoBehaviour
{

    private Rigidbody2D rb;
    public bool facingRight = true;
    protected Animator animator;
    public int hitPoints = 3;

    protected float movementSpeed = 1.0f;

    private int _charactersInRange = 0;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void Move(float moveHorizontal)
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Ninja Hurt")) return;

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Ninja Idle") || animator.GetCurrentAnimatorStateInfo(0).IsName("Ninja Walk"))
        {
            if ((moveHorizontal > 0 && !facingRight) || (moveHorizontal < 0 && facingRight)) StartFlip();
            else if (moveHorizontal == 0) StartWait();
            else StartWalk();
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Ninja Walk"))
        {
            Vector2 movement = new Vector2(moveHorizontal, 0.0f);
            rb.velocity = (movement);
        }
    }

    public void StartCrouch()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Ninja Idle"))
        {
            animator.SetTrigger("startCrouch");
        }
    }

    public void StartJump()
    {

    }

    public void Hit(float damage)
    {
    }

    public void StartWait()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Ninja Idle"))
        {
            animator.ResetTrigger("startCrouch");
            animator.SetTrigger("startWaiting");
        }        
    }

    public void StartWalk()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Ninja Walk"))
        {
            animator.SetTrigger("startWalking");
        }
    }

    public void StartFlip()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Ninja Flip"))
        {
            facingRight = !facingRight;
            animator.SetTrigger("startFlipping");
        }
    }

    public void EndFlip()
    {
        animator.ResetTrigger("startFlipping");
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public virtual void StartHurt()
    {
        hitPoints--;
        animator.ResetTrigger("startWalking");
        animator.ResetTrigger("startFlipping");
        animator.ResetTrigger("startWaiting");
        if (hitPoints <= 0) {
            StartDie();
        } else
        {
            animator.SetTrigger("startHurt");
        }
        
    }

    public void StartDie()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Ninja Die"))
        {
            animator.ResetTrigger("startHurt");
            animator.SetTrigger("startDie");
        }
    }

}
