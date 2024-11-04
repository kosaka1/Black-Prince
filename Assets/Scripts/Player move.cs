using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{
    //force the player jumps at
    public float jumpForce;

    public float moveSpeed;

    public static bool nowMove = true;
    public static Vector4 playerPos;
    //bool to check if player is on the gorund
    public bool grounded;

    //reference to the player rigid body 2D
    public Rigidbody2D playerBody;
    public GameObject thx;

    void Start()
    {
        //get reference to players Rigidbody2D component
        playerBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        

        if (Input.GetMouseButton(0) && nowMove)
        {
            if (touchPos.x < -6.55 + 0.7 && touchPos.x > -6.55 - 0.7 && touchPos.y < -3.1 + 0.4 && touchPos.y > -3.1 - 0.4 && grounded)  //makes player jump
            {
                //player jumps
                playerBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }

            if (touchPos.x < -5.7 + 0.7 && touchPos.x > -5.7 - 0.7 && touchPos.y < -4 + 0.4 && touchPos.y > -4 - 0.4)
            {
                playerBody.AddForce(Vector2.right * moveSpeed);
            }

            if (touchPos.x < -7.4 + 0.7 && touchPos.x > -7.4 - 0.7 && touchPos.y < -4 + 0.4 && touchPos.y > -4 - 0.4)
            {
                playerBody.AddForce(Vector2.left * moveSpeed);
            }

            if (touchPos.x < 7.45 + 0.7 && touchPos.x > 7.45 - 0.7 && touchPos.y < -3.55 + 0.5 && touchPos.y > -3.55 - 0.5)
            {
                nowMove = false;
                playerPos.x = playerBody.position.x;
            }
        }
        else
        {
            playerBody.AddForce(Vector2.left * 0);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        //check if the collsion is happening with a game object with "ground" tag.
        if (collision.gameObject.tag == "ground")
        {
            grounded = true;
        }
        else if (collision.gameObject.tag == "block")
        {
            grounded = true;
        }
        else if(collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene(0);
        }
        else if (collision.gameObject.tag == "Exit")
        {
            thx.SetActive(true);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //check if the collsion is happening with a game object with "ground" tag.
        if (collision.gameObject.tag == "ground" || collision.gameObject.tag == "block")
        {
            grounded = false;
        }

    }
}
