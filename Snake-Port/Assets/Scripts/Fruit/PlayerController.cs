using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float dirX, dirY, movespeed;
    private int snakeBodySize;
    private List<Vector2Int> snakeMovePositionList;

    [SerializeField]
    private Rigidbody2D Fruits;

    [SerializeField]
    private Rigidbody2D SnakeBody;

    private Vector2 currentPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movespeed = 20;
        SpawnFruit();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal") * movespeed;
        dirY = Input.GetAxisRaw("Vertical") * movespeed;
     
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, dirY);
    }

    private void SpawnFruit()
    {
        bool FruitSpawned = false;
        while (!FruitSpawned)
        {
            Vector3 FruitPosition = new Vector3(Random.Range(-8f, 8f), Random.Range(-5f, 5f), 0f);
            if ((FruitPosition - transform.position).magnitude < 3)
            {
                continue;
            }
            else
            {
                Instantiate(Fruits, FruitPosition, Quaternion.identity);
                FruitSpawned = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("GameOver");
        }
        if (collision.gameObject.CompareTag("Player"))
        {
           
        }
        ScoreScript.scoreValue += 10;
        SpawnFruit();
        Instantiate(SnakeBody);
    }

}
