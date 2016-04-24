using UnityEngine;
using System.Collections;

public class PlayerController : NinjaController {

    public Camera playerCamera;
    protected CircleCollider2D cameraCloseCollider;
    protected CircleCollider2D cameraFarCollider;

    private int charactersInRange = 0;

    public override void Awake()
    {
        base.Awake();
    }

    void FixedUpdate()
    {
        CheckTouchingFloor();

        if (Input.GetKeyDown(KeyCode.Q)) DoBasicAttack();
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
