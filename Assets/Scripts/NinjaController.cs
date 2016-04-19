using UnityEngine;
using System.Collections;

public class NinjaController : MonoBehaviour
{

    private Rigidbody2D rb;
    public bool facingRight = true;
    private Animator animator;

    protected enum NinjaStates { IDLE, WALKING, FLIPPING };

    protected NinjaStates currentNinjaState = NinjaStates.IDLE;

    protected float movementSpeed = 1.0f;

    private int _charactersInRange = 0;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void Move(float moveHorizontal)
    {
        switch(currentNinjaState)
        {
            case NinjaStates.IDLE:
            case NinjaStates.WALKING:
                if ((moveHorizontal > 0 && !facingRight) || (moveHorizontal < 0 && facingRight)) StartFlip();
                else if (moveHorizontal == 0) StartWait();
                else StartWalk();
                break;
            case NinjaStates.FLIPPING:
            default:
                break;
        }

        Vector2 movement = new Vector2(moveHorizontal, 0.0f);
        rb.velocity = (movement);
    }

    public void StartWait()
    {
        currentNinjaState = NinjaStates.IDLE;
        animator.SetTrigger("startWaiting");
    }

    public void StartWalk()
    {
        currentNinjaState = NinjaStates.WALKING;
        animator.SetTrigger("startWalking");
    }

    public void StartFlip()
    {
        currentNinjaState = NinjaStates.FLIPPING;
        facingRight = !facingRight;
        animator.SetTrigger("startFlipping");
    }

    public void EndFlip()
    {
        animator.ResetTrigger("startFlipping");
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

        currentNinjaState = NinjaStates.IDLE;
    }
}
