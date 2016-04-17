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
            GameObject clone = Instantiate(shuriken, transform.position, transform.rotation) as GameObject;
            Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();

            Vector2 movement = new Vector2(1f, 0.0f);

            rb.velocity = (movement);
            rb.angularVelocity   = 720f;
            Destroy(clone, 6);
        }
	}
}
