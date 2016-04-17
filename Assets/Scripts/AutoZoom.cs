using UnityEngine;
using System.Collections;

public class AutoZoom : MonoBehaviour {

    public bool zoomIn = false;
    public float zoomInDelta = 0.02f;
    public float zoomOutDelta = 0.02f;

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

        Camera _camera = GetComponent<Camera>();
        Vector3 cameraPosition = _camera.transform.position;

        if (zoomIn && cameraPosition.z < maxZ) cameraPosition.z += zoomInDelta;
        else if (!zoomIn && cameraPosition.z > minZ) cameraPosition.z += -zoomOutDelta;

        if (zoomIn && cameraPosition.y > minY) cameraPosition.y += -zoomInDelta;
        else if (!zoomIn && cameraPosition.y < maxY) cameraPosition.y += zoomOutDelta;

        _camera.transform.position = cameraPosition;
	}
}
