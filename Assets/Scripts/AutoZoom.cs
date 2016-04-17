using UnityEngine;
using System.Collections;

public class AutoZoom : MonoBehaviour {

    private float maxZ;
    private float minZ;

    private float maxY;
    private float minY;

	// Use this for initialization
	void Awake () {

        Vector3 cameraPosition = GetComponent<Camera>().transform.position;
        minZ = cameraPosition.z;
        maxY = cameraPosition.y;
        maxZ = minZ + 0.6f;
        minY = maxY - 0.6f;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        float move = Input.GetAxis("Vertical");
        bool zoomIn = move != 0;

        Camera _camera = GetComponent<Camera>();
        Vector3 cameraPosition = _camera.transform.position;

        if (zoomIn && cameraPosition.z < maxZ) cameraPosition.z += 0.01f;
        else if (!zoomIn && cameraPosition.z > minZ) cameraPosition.z += -0.01f;

        if (zoomIn && cameraPosition.y > minY) cameraPosition.y += -0.01f;
        else if (!zoomIn && cameraPosition.y < maxY) cameraPosition.y += 0.01f;

        _camera.transform.position = cameraPosition;
        print(cameraPosition);
	}
}
