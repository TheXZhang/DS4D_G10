using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10;

    private Transform m_transform;
    private Vector3 m_moveDirection;
    private Rigidbody m_rigidBody;

    public float rotationSpeed = 1.0f;
    public float MoveSpeed = 1.0f;
    public float durationToSit = 5.0f;

    private Animator Anim;
    float lastTime;

    public float speed = 1;

    public static AudioSource[] m_ArrayMusic;
    public static AudioSource walk;
    public static AudioSource open;


    void Start()
    {
        lastTime = Time.time;
        m_ArrayMusic = gameObject.GetComponents<AudioSource>();
        walk = m_ArrayMusic[0];
        open = m_ArrayMusic[1];
        GetComponent<AudioSource>().volume = 0.1f;

    }

    void Awake()
    {
        m_transform = transform;
        m_rigidBody = GetComponent<Rigidbody>();
        Anim = GetComponent<Animator>();
    }


    void Update()
    {
       
       
       

        transform.position += transform.forward * Input.GetAxis("Vertical") * Time.deltaTime;
        //transform.position += transform.right * Input.GetAxis("Horizontal") * Time.deltaTime;
       // float horizontal = Input.GetAxisRaw("Horizontal");
       // float vertical = Input.GetAxisRaw("Vertical");
       // m_moveDirection = new Vector3( horizontal, 0, vertical).normalized;
        m_transform.Rotate(0, Input.GetAxis("Horizontal"), 0);

        


        if (Input.GetKeyDown(KeyCode.A))
        {
            Anim.SetBool("Left", true);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Anim.SetBool("Right", true);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Anim.SetBool("Jogging", true);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            Anim.SetBool("Left", false);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            Anim.SetBool("Right", false);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            Anim.SetBool("Jogging", false);
        }


        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {

            if (Anim.GetBool("Sit") == true)
            {
                Anim.SetBool("StartMoving", true);

            }
            else
            {
                lastTime = Time.time;
                Anim.SetBool("StartMoving", false);

            }

        }



        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            lastTime = Time.time;
        }

        if ((Time.time - lastTime) >= durationToSit)
        {
            Anim.SetBool("Sit", true);
        }
        else
        {
            Anim.SetBool("Sit", false);
        }

        /*if( (Anim.GetBool("Sit") == true) && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)))
        {
           
            Anim.SetBool("Sit", false);
            Anim.SetBool("Start moving", true);
        }*/
        //Debug.Log(lastTime);


    

   
    }

    void FixedUpdate()
    {
      
        if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
            walk.Play();
        else if (!Input.GetButton("Horizontal") && !Input.GetButton("Vertical") && walk.isPlaying)
            walk.Stop(); // or Pause()


    }

}
