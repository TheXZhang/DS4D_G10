using UnityEngine;
using System.Collections;

public class PlanetGravity : MonoBehaviour
{
    //The gravity of the planet
    public float gravity = -10f;

    private Transform m_transform;

    void Awake()
    {
        m_transform = transform;
    }


    public void AddGravity(Transform targetObject)
    {
        //The gravity direction of the planet
        Vector3 gravityDirection = (targetObject.position - m_transform.position).normalized;
        Vector3 targetUpDirection = targetObject.transform.up;
        //Add the gravity to the target object
        targetObject.rotation = Quaternion.FromToRotation(targetUpDirection, gravityDirection) * targetObject.rotation;
        targetObject.GetComponent<Rigidbody>().AddForce(gravity * gravityDirection);

        //Change the up direction of the target object to the reverse direction of gravity
       
        
       // targetObject.rotation = Quaternion.Slerp(targetObject.rotation, targetRotation, Time.deltaTime * 100);
    }
}