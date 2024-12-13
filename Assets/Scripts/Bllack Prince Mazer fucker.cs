using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Analytics;
using static Unity.Collections.AllocatorManager;




public class BllackPrinceMazerfucker : MonoBehaviour
{
    public GameObject block1;
    public GameObject block2;
    // Start is called before the first frame update
    void Start()
    {
        List<List<bool>> map = new List<List<bool>>();
        for(int i = 0; i < 11; i++)
        {
            map.Add(new List<bool>());
            for(int j = 0; j < 17; j++)
            {
                map[i].Add(false);
            }
        }
        while (true)
        {
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 17; j++)
                {
                    map[i][j] = false;
                }
            }
            System.Random rnd = new System.Random();
            prop(map, rnd.Next(0, 17), rnd.Next(0, 11), rnd);

            prop(map, rnd.Next(0, 17), rnd.Next(0, 11), rnd);

            prop(map, rnd.Next(0, 17), rnd.Next(0, 11), rnd);

            List<List<bool>> copiedList = new List<List<bool>>();
            for (int i = 0; i < 11; i++)
            {
                copiedList.Add(new List<bool>(map[i]));
            }

            if (PIZDUC(copiedList))
            {
                break;
            }
        }
        for (int i = 0; i < 11; i++)
        {
            for (int j = 0; j < 17; j++)
            {
                if (map[i][j])
                {
                    SpawnBlock(i, j);
                }
            }
        }
    }

    public void SpawnBlock(int h, int w)
    {
        Vector3 spawnPos = new Vector3();
        spawnPos.x = w - 8;
        spawnPos.y = h - 5;

        Instantiate(block1, spawnPos, Quaternion.identity);
        Instantiate(block2, spawnPos, Quaternion.identity);

    }

    void prop(List<List<bool>> map, int x_start, int y_start, System.Random rnd)
    {
        if (!((x_start == 16 || x_start == 1) && y_start == 9) && !((x_start == 16 || x_start == 1) && y_start == 8))
        {
            if (map[y_start][x_start] == true)
            {
                return;
            }
            map[y_start][x_start] = true;
            if (x_start > 0 && rnd.Next(0, 99) < 35)
            {
                prop(map, x_start - 1, y_start, rnd);
            }
            if (y_start > 0 && rnd.Next(0, 99) < 35)
            {
                prop(map, x_start, y_start - 1, rnd);
            }
            if (x_start < 10 && rnd.Next(0, 99) < 35)
            {
                prop(map, x_start + 1, y_start, rnd);
            }
            if (y_start < 10 && rnd.Next(0, 99) < 35)
            {
                prop(map, x_start, y_start + 1, rnd);
            }
        }
    }

    bool PIZDUC(List<List<bool>> map, int h = 9, int w = 15)
    {
        bool left = false, right = false, up = false, down = false;
        if (h - 1 >= 0 && !map[h][w] && !map[h - 1][w])
        {

            if ( h == 9 && w == 1)
            {
                return true;
            }
            map[h][w] = true;
            if (h < 9)
            {
                down = PIZDUC(map, h + 1, w);
            }
            if (h > 1)
            {
                up = PIZDUC(map, h - 1, w);
            }
            if (w > 1)
            {
                left = PIZDUC(map, h, w - 1);
            }

            if (w < 15)
            {
                right = PIZDUC(map, h, w + 1);
            }

            if (down || up || left || right) { 
                return true;
            }
        }


        return false;
    }

    // Update is called once per frame
    // Update is called once per frame
    void Update()
    {
        
    }
}
