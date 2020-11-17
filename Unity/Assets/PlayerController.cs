using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10;

    private Transform m_transform;
    private Vector3 m_moveDirection;
    private Rigidbody m_rigidBody;

    void Awake()
    {
        m_transform = transform;
        m_rigidBody = GetComponent<Rigidbody>();
    }


    void Update()
    {
        m_moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, -Input.GetAxis("Vertical")).normalized;
    }


    void FixedUpdate()
    {
        m_rigidBody.MovePosition(m_transform.position + m_transform.TransformDirection(m_moveDirection) * moveSpeed * Time.deltaTime);
    }
}
