using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity : MonoBehaviour
{
    // Start is called before the first frame update
    public float gravityForce = 30f;

    public PlayerMove playerMove;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        if (playerMove.playerStage == "OnSpace")
        {
            Vector2 gravityPosition = new Vector2(transform.position.x, transform.position.y);
            Vector2 playerPosition = new Vector2(playerMove.transform.position.x, playerMove.transform.position.y);
            Vector2 gravityDirection = gravityPosition - playerPosition;
            playerMove.rb2D.AddForce(gravityDirection * gravityForce);
        }
        
    }
}
