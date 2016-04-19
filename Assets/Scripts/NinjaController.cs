using UnityEngine;
using System.Collections;

public class NinjaController : MonoBehaviour
{

    private Rigidbody2D rb;
    public bool facingRight = true;
    protected Animator animator;

    protected enum NinjaStates { IDLE, WALKING, FLIPPING, HURT, PUNCH };

    protected NinjaStates currentNinjaState = NinjaStates.IDLE;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void Move(float moveHorizontal)
    {
        if (currentNinjaState == NinjaStates.IDLE || currentNinjaState == NinjaStates.WALKING)
        {
            if ((moveHorizontal > 0 && !facingRight) || (moveHorizontal < 0 && facingRight)) StartFlip();
            else if (moveHorizontal == 0) StartWait();
            else StartWalk();
        }

        if (currentNinjaState == NinjaStates.WALKING)
        {
            Vector2 movement = new Vector2(moveHorizontal, 0.0f);
            rb.velocity = (movement);
        }
    }

    void LateUpdate()
    {
        AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);
        if (state.IsName("Ninja Flip")) currentNinjaState = NinjaStates.FLIPPING;
        else if (state.IsName("Ninja Idle")) currentNinjaState = NinjaStates.IDLE;
        else if (state.IsName("Ninja Walk")) currentNinjaState = NinjaStates.WALKING;
    }

    public void Hit(float damage)
    {
    }

    public void StartWait()
    {
        animator.SetTrigger("startWaiting");
    }

    public void StartWalk()
    {
        animator.SetTrigger("startWalking");
    }

    public void StartFlip()
    {
        facingRight = !facingRight;
        animator.SetTrigger("startFlipping");
    }

    public void EndFlip()
    {
        animator.ResetTrigger("startFlipping");
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
