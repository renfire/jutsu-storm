using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public GameObject[] enemyType;
    public bool facingRight = true;
    private Animator _animator;

    // Use this for initialization
    void Start () {
        _animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        print(other.name);
        if (other.name == "Ninja")
        {
            if (other.transform.position.x < transform.position.x && facingRight)
            {
                Flip();
            }
        }
        else if (other.name == "Fuuma_Shuriken 1(Clone)") {
            _animator.SetTrigger("startDie");
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
