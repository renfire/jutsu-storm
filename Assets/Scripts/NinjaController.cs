using UnityEngine;
using System.Collections;

public class NinjaController : MonoBehaviour
{
    // DIRECTION
    public bool facingRight = true;

    // LIFE AND DAMAGE
    public int hitPoints = 3;

    // PHYSICS
    private Rigidbody2D rb;
    protected Animator animator;
    public LayerMask whatIsGround;

    // FX
    public GameObject smoke;

    private int _charactersInRange = 0;

    public virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetBool("isOnFloor", true);
    }

    public virtual void Update()
    {
        CheckTouchingFloor();
    }
    
    protected void CheckTouchingFloor()
    {
        RaycastHit2D hit = Physics2D.Linecast(transform.position, new Vector2(transform.position.x, transform.position.y - 1f), whatIsGround);
        animator.SetBool("isOnFloor", (hit.distance < 0.27f));
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

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Ninja Walk")) rb.velocity = new Vector2(moveHorizontal, rb.velocity.y);
    }

    public void DoBasicAttack()
    {
        GameObject smokeClone = Instantiate(smoke, transform.position, transform.rotation) as GameObject;
        print(smokeClone);

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
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Ninja Jump"))
        {
            animator.SetTrigger("startJump");
            rb.AddForce(new Vector2(0, 3f), ForceMode2D.Impulse);
        }
    }

    public void Hit(float damage)
    {
    }

    public void StartBlock()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Ninja Blocking") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Ninja Block") && (animator.GetCurrentAnimatorStateInfo(0).IsName("Ninja Idle") || animator.GetCurrentAnimatorStateInfo(0).IsName("Ninja Walk")))
        {
            animator.SetTrigger("startBlock");
            animator.ResetTrigger("startWait");
            animator.ResetTrigger("startWalk");
        }
    }

    public void StartWait()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Ninja Idle") && (!animator.GetCurrentAnimatorStateInfo(0).IsName("Ninja Jump") || animator.GetBool("isOnFloor")))
        {
            animator.ResetTrigger("startBlock");
            animator.ResetTrigger("startCrouch");
            animator.SetTrigger("startWaiting");
        }        
    }

    public void StartWalk()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Ninja Walk") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Ninja Jump"))
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
