using UnityEngine;
using System.Collections;

public class PlayerController : NinjaController {

    public Camera playerCamera;

    private int charactersInRange = 0;

    void FixedUpdate()
    {
        CheckTouchingFloor();

        if (Input.GetKeyDown(KeyCode.Q)) StartJump();
        if (Input.GetKey(KeyCode.W)) StartBlock();
        if (Input.GetKeyDown(KeyCode.E)) { }
        if (Input.GetKeyDown(KeyCode.R)) { }

        if (Input.GetKey(KeyCode.RightArrow)) Move(1.0f);
        if (Input.GetKey(KeyCode.LeftArrow)) Move(-1.0f);
        if (Input.GetKeyDown(KeyCode.UpArrow)) StartJump();
        if (Input.GetKey(KeyCode.DownArrow)) StartCrouch();

        if (!Input.anyKey) StartWait();

        Vector3 cameraPositon = new Vector3(transform.position.x, playerCamera.transform.position.y, playerCamera.transform.position.z);
        playerCamera.transform.position = cameraPositon;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name != "Fuuma_Shuriken 1(Clone)")
        {
            charactersInRange++;
            if (charactersInRange > 0)
            {
                playerCamera.GetComponent<AutoZoom>().zoomIn = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name != "Fuuma_Shuriken 1(Clone)")
        {
            charactersInRange--;
            if (charactersInRange <= 0)
            {
                playerCamera.GetComponent<AutoZoom>().zoomIn = false;
            }
        }
    }
}
