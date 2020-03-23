/*
 * Script:                 PlayerController
 * Autor:                  Damian Jones
 * Date Created:           2019-11-27
 * Date Last Updated:      2020-01-09
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    // animation
    private Animator anim;

    // controls
    private string m_die = "r";

    // movement
    public static float speed = 0f;
    private float jumpSpeed = 5f;
    public bool isGrounded = true;
    public static bool moveinAir = true;
    public float forcetoAdd = 10;
    private bool isFalling = false;
    
    /*// delay                                  not sure if needed--------------------
    private int delayLength = 12;
    private float delayDeath = 3.5f;
    private int delayAnimLength = 6;
    private int delayAnimCount = 0;
    private int delayCount = 0;
    private float deathCount = 0.0f;
    private bool delay = false;
    private bool delayAnim = false;
    //-----------------------------------------------------------------------------*/
    // life and reset
    public static float m_health = 1;
    public static bool isDead = false;

    // Audio
    public float Volume; 
    public bool alreadyPlayedDeath = false;
    public bool alreadyPlayedRun = false;


    void Awake()
    {
        moveinAir = true;
        speed = 0f;
        m_health = 100f;
        isDead = false;
    }

    void Start()
    {
       
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(isGrounded);

        if (isDead)
        {
            anim.SetBool("IsFalling", false);
        }


       /* if (!isDead)
        {
            // player jump
            /*if (Input.GetButton("Jump") && isGrounded)
            {
                //anim.SetBool("IsJumping", true);
                isGrounded = false;
                /*delay = true;
                delayAnim = true;
                GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpSpeed, ForceMode2D.Impulse);
            }
        
            // player suduko
            if (Input.GetKey(m_die))
            {
                m_health = 0;
            }
        }*/

        // player run
        if (Input.GetKey(KeyCode.LeftShift))
        {
            // run
            speed = 10;
        }
        else
        {
            // walk
            speed = 5;
        }

        // check if player is alive
        if (m_health <= 0)
        {
           // anim.SetBool("IsDead", true);
            //deathCount += Time.deltaTime;
            //Debug.Log(deathCount);

            isDead = true;
            if(!alreadyPlayedDeath)
            {
                alreadyPlayedDeath = true;
            }
           /* if (deathCount >= delayDeath)
            {
               // LevelReset();
                deathCount = 0.0f;
                isDead = false;
                m_health = 100;
            }*/
        }

        if (isFalling)
        {

        }
    }

    void FixedUpdate()
    {
        if (!isDead)
        {
            // player movement
            if (moveinAir)
            {
               // anim.SetBool("IsIdle", false);
               // anim.SetBool("IsWalking", true);
               transform.Translate((Input.GetAxis("Horizontal")) * speed * Time.deltaTime, 0f, 0f);

                if (Input.GetKey("a"))
                {
            

                }
                else if (Input.GetKey("d"))
                {
                }
                else
                {
                    if (Input.GetKey(KeyCode.A))
                        GetComponent<Rigidbody2D>().AddForce(-Vector2.right * forcetoAdd);

                    if (Input.GetKey(KeyCode.D))
                        GetComponent<Rigidbody2D>().AddForce(Vector2.right * forcetoAdd);

                    if(Input.GetKey(KeyCode.W))
                        GetComponent<Rigidbody2D>().AddForce(Vector2.up * forcetoAdd);

                    if(Input.GetKey(KeyCode.S))
                        GetComponent<Rigidbody2D>().AddForce(-Vector2.up * forcetoAdd);
                }
            }
        }
    }

        void OnCollisionStay2D(Collision2D collision)
        {
            //Debug.Log(collision.gameObject.tag);
            // am I colliding with the ground or a box?
            if (collision.gameObject.tag == "Fruit" || collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Object" || collision.gameObject.tag == "ButtonHead")
            {
           
            }
        }

        void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Fruit" || collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Object" || collision.gameObject.tag == "ButtonHead")
            {
               
            }
        }

        
    public void KillPlayer()
         {
             m_health = 0;
         }
    
}

