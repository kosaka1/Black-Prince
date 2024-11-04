using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{

    Rigidbody2D playerBody;

    public GameObject block;
    public Transform spawnPoint;
    public float downSpeed;
    public static bool isSpawned = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSpawned && !NewBehaviourScript.nowMove)
        {
            SpawnBlock();
        }
    }

    public void SpawnBlock()
    {
        Vector3 spawnPos = spawnPoint.position;

        spawnPos.x = NewBehaviourScript.playerPos.x;

        Instantiate(block, spawnPos, Quaternion.identity);

        isSpawned = true;
    }
}
