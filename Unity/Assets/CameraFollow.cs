using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    

    public Transform player;
    public Transform earth;

    public float smoothing = 5f;


    public float minZoom = 5f;
    public float maxZoom = 15f;
    public float zoomSpeed = 4f;

    public float currentZoom = 4f;




    void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
    }


    void LateUpdate()
    {


        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            currentZoom++;
        }
        else if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            currentZoom--;

        }

            Vector3 offset = player.position - earth.position;

            Vector3 targetCamPos = player.position + offset * currentZoom;

            transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
            transform.LookAt(earth);
            transform.RotateAround(transform.position, -targetCamPos, 20 * Time.deltaTime);


    }
}
