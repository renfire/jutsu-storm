using UnityEngine;
using System.Collections;

public class ShurikenController : MonoBehaviour {

    public GameObject shuriken;
    private int ammo = 2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            PlayerController myParent = transform.parent.GetComponent<PlayerController>();
            Vector2 movement;
            if (myParent.facingRight) movement = new Vector2(1f, 0.0f);
            else movement = new Vector2(-1f, 0.0f);
            GameObject clone = Instantiate(shuriken, transform.position, transform.rotation) as GameObject;
            Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();

            rb.velocity = (movement);
            rb.angularVelocity   = 720f;
            Destroy(clone, 6);
        }
	}
}
