﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb;
    bool facingRight = true;
    public Camera _camera;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        if ((moveHorizontal > 0 && !facingRight) || (moveHorizontal < 0 && facingRight)) Flip();

        Vector2 movement = new Vector2(moveHorizontal, 0.0f);

        rb.velocity = (movement);            
    }

    void OnTriggerEnter2D()
    {
       _camera.GetComponent<AutoZoom>().zoomIn = true;
    }

    void OnTriggerExit2D()
    {
        _camera.GetComponent<AutoZoom>().zoomIn = false;
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
