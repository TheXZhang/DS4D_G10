using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    public PlanetGravity planetGravity;


    private Transform m_transform;

    void Awake()
    {
        //planetGravity = GameObject.FindGameObjectWithTag("planet").GetComponent<planetGravity>();
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        
        m_transform = transform;
    }


    void Update()
    {
        planetGravity.AddGravity(m_transform);
    }
}
