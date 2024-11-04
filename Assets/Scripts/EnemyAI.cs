using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.LegacyInputHelpers;

public class EnemyAI : MonoBehaviour
{
    Rigidbody2D enemyBody;

    public float moveSpeed = 1;
    public enum go
    {
        left, right
    }
    public static go direction = go.left;
    // Start is called before the first frame update
    void Start()
    {
        enemyBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (direction)
        {
            case go.right:
                enemyBody.velocity = Vector3.right * moveSpeed;
                break;
            case go.left:
                enemyBody.velocity = Vector3.left * moveSpeed;
                break;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Wall"))
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
    }
}
