using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb;
    public bool facingRight = true;
    public Camera _camera;
    private Animator _animator;

    private int _charactersInRange = 0;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        if ((moveHorizontal > 0 && !facingRight) || (moveHorizontal < 0 && facingRight))
        {
            facingRight = !facingRight;
            _animator.SetTrigger("startFlipping");
            return;
        }

        if (moveHorizontal == 0) _animator.SetTrigger("startWaiting");
        else _animator.SetTrigger("startWalking");

        Vector2 movement = new Vector2(moveHorizontal, 0.0f);

        rb.velocity = (movement);

        Vector3 characterPosition = transform.position;
        Vector3 cameraPositon = new Vector3(characterPosition.x, _camera.transform.position.y,  _camera.transform.position.z);

        _camera.transform.position = cameraPositon;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name != "Fuuma_Shuriken 1(Clone)")
        {
            _charactersInRange++;
            if (_charactersInRange > 0)
            {
                _camera.GetComponent<AutoZoom>().zoomIn = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name != "Fuuma_Shuriken 1(Clone)")
        {
            _charactersInRange--;
            if (_charactersInRange <= 0)
            {
                _camera.GetComponent<AutoZoom>().zoomIn = false;
            }
        }
    }

    void Flip()
    {
//        Vector3 theScale = transform.localScale;
//        theScale.x *= -1;
//        transform.localScale = theScale;
    }
}
