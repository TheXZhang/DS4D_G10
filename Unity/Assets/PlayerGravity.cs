using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    public PlanetGravity planetGravity;

    private Transform m_transform;

    void Awake()
    {
        m_transform = transform;
    }


    void Update()
    {
        planetGravity.AddGravity(m_transform);
    }
}
