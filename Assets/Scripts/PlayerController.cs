using UnityEngine;
using System.Collections;

public class PlayerController : NinjaController {

    public Camera playerCamera;

    private int charactersInRange = 0;

    void FixedUpdate()
    {
        Move(Input.GetAxis("Horizontal"));

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
