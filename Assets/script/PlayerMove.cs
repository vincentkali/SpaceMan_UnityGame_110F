using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public string playerStage = "OnGround";
    public float jumpForce = 50f;
    public Rigidbody2D rb2D;
    public Text gameOver;
    // Start is called before the first frame update
    void Start()
    {
        playerStage = "OnGround";
        rb2D = GetComponent<Rigidbody2D>();
        gameOver.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && playerStage == "OnGround")
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 playerPosition = new Vector2(transform.position.x, transform.position.y);
            Vector2 jumpDirection = mousePos - playerPosition;
            Debug.Log(jumpDirection);

            rb2D.AddForce(jumpDirection * jumpForce);
            playerStage = "OnSpace";

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            rb2D.velocity = Vector2.zero;
            Debug.Log("collide");
            playerStage = "OnGround";
        }
        if (collision.collider.tag == "Obstacle")
        {
            Debug.Log("you dead");
            gameOver.enabled = true;
        }
    }

}
