﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemyCollision : MonoBehaviour
{

     private void OnTriggerEnter2D(Collider2D other)
    {
   

        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("GameOver");
        }
        if (other.gameObject.CompareTag("Fruits"))
        {
            Destroy(other.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
