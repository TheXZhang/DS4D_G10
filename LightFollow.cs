using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFollow : MonoBehaviour
{


    public Transform camera;
    public Transform earth;

    void LateUpdate()
    {


       
        Vector3 targetCamPos = camera.position;

        transform.position = Vector3.Lerp(transform.position, targetCamPos,  Time.deltaTime);
        transform.LookAt(earth);
        transform.RotateAround(transform.position, -targetCamPos, 20 * Time.deltaTime);


    }
}
