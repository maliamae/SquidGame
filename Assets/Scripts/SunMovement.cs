using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMovement : MonoBehaviour
{
    //public float distance = 5f;
    private Vector2 cameraPos;
    Transform cam;
    private float startPosX;
    private float startPosZ;

    private void Start()
    {
        cam = Camera.main.transform;
        startPosX = transform.position.x;
        startPosZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(cam.position.x + startPosX, transform.position.y, startPosZ);
        //cameraPos = Camera.main.ScreenToViewportPoint(transform.position);
        //Debug.Log(cameraPos);
        //transform.position = new Vector3(cameraPos.x, cameraPos.y, 0f);
    }
}
