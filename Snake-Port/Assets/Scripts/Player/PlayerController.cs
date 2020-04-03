/*
 * Script:                 PlayerController
 * Autor:                  Damian Jones
 * Date Created:           2019-11-27
 * Date Last Updated:      2020-01-09
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private Rigidbody2D Fruits;

    bool Left, Right, Up, Down;
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
        speed = 10f;
        m_health = 100f;
        isDead = false;
    }

    void Start()
    {

        anim = GetComponent<Animator>();
        Instantiate(Fruits);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(isGrounded);

        if (isDead)
        {
            anim.SetBool("IsFalling", false);
        }

        // player run
  

        // check if player is alive
        if (m_health <= 0)
        {
            isDead = true;
            if (!alreadyPlayedDeath)
            {
                alreadyPlayedDeath = true;
            }
        }
    }

    void FixedUpdate()
    {
        if (!isDead)
        {
            if (moveinAir)
            {
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
                    {
                        GetComponent<Rigidbody2D>().AddForce(-Vector2.right * forcetoAdd);
                        bool Right = false;
                        bool Left = true;
                    } 

                    if (Input.GetKey(KeyCode.D))
                    {
                        GetComponent<Rigidbody2D>().AddForce(Vector2.right * forcetoAdd);
                        bool Right = true;
                        bool Left = false;
                    }

                    if (Input.GetKey(KeyCode.W))
                    {
                        GetComponent<Rigidbody2D>().AddForce(Vector2.up * forcetoAdd);
                        bool Up = true;
                        bool Down = false;
                    }

                    if (Input.GetKey(KeyCode.S)) { 
                        GetComponent<Rigidbody2D>().AddForce(-Vector2.up * forcetoAdd);
                        bool Down = true;
                        bool Up = false;
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(collision.gameObject.tag);
        
        if (other.gameObject.CompareTag("Fruits"))
        {
            Destroy(other.gameObject);
            Instantiate(Fruits);
           
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("GameOver");
        }

    }


        
    public void KillPlayer()
         {
             m_health = 0;
         }
    
}

