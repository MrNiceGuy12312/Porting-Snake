using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ManaBar : MonoBehaviour
{
    private float mana;
    private Image barImage;
    public GameObject player;
    private void Start()
    {

        //finding anything tagged as BAR and getting an image component
        barImage = GameObject.FindGameObjectWithTag("bar").GetComponent<Image>();

        //assinging player to the gameobject tagged as player
        player = GameObject.FindWithTag("Player");
       
    }
 
    private void Update()
    {     
        //assinging mana with the values of mana refrenced through PlayerController
       // mana = PlayerController.m_mana;
        barImage.fillAmount = mana / 100;
    }
}
