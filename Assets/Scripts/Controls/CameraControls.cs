using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    private float initialSize;

    public float moveSpeed = 10f;
    public float moveZone = 20f;

    void Start()
    {
        initialSize = GetComponent<Camera>().orthographicSize;
    }

    void Update()
    {
        float zoomAmount = Input.GetAxis("Mouse ScrollWheel");
        float newSize = GetComponent<Camera>().orthographicSize - zoomAmount * 10f;

        float minSize = 1f;
        float maxSize = 30f;
        newSize = Mathf.Clamp(newSize, minSize, maxSize);

        GetComponent<Camera>().orthographicSize = newSize;

        Vector3 pos = transform.position;
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        if (mouseX < moveZone)
        {
            pos.x -= moveSpeed * Time.deltaTime;
        }
        else if (mouseX > Screen.width - moveZone)
        {
            pos.x += moveSpeed * Time.deltaTime;
        }
        if (mouseY < moveZone)
        {
            pos.y -= moveSpeed * Time.deltaTime;
        }
        else if (mouseY > Screen.height - moveZone)
        {
            pos.y += moveSpeed * Time.deltaTime;
        }
        transform.position = pos;
    }
}