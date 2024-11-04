using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemyAI;

public class Blocks : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;

    //bool to check if player is on the gorund
    public bool grounded;

    //reference to the player rigid body 2D
    Rigidbody2D playerBody;
    //public float downSpeed;
    void Start()
    {
        //get reference to players Rigidbody2D component
        playerBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0) && !NewBehaviourScript.nowMove)
        {
            playerBody.velocity = Vector3.down * moveSpeed;
            //playerBody.bodyType = RigidbodyType2D.Dynamic;
            if (touchPos.x < -5.7 + 0.7 && touchPos.x > -5.7 - 0.7 && touchPos.y < -4 + 0.4 && touchPos.y > -4 - 0.4)
            {
                playerBody.velocity = Vector3.right * moveSpeed;
                
            }

            if (touchPos.x < -7.4 + 0.7 && touchPos.x > -7.4 - 0.7 && touchPos.y < -4 + 0.4 && touchPos.y > -4 - 0.4)
            {
                playerBody.velocity = Vector3.left * moveSpeed;
                
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check if the collsion is happening with a game object with "ground" tag.
        if (collision.CompareTag("ground"))
        {
            NewBehaviourScript.nowMove = true;
            playerBody.bodyType = RigidbodyType2D.Static;
            BlockManager.isSpawned = false;
        }

        if (collision.CompareTag("enemy"))
        {
            switch (direction)
            {
                case go.right:
                    direction = go.left;
                    break;
                case go.left:
                    direction = go.right;
                    break;
            }
        }

        if (collision.CompareTag("player"))
        {
            
        }
    }

}
