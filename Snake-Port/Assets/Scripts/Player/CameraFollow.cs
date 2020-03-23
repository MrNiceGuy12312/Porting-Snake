/*
 * Script:                 MoveObjects
 * Autor:                  Damian Jones
 * Date Created:           2019-12-12
 * Date Last Updated:      2019-12-16
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Vector3 pos;
    GameObject player;

    public float playerZ = 10;

    void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float playerX = player.transform.position.x;
        float playerY = player.transform.position.y;

        pos = new Vector3(playerX, playerY, -playerZ);

        gameObject.transform.position = pos;
    }
}
