using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBackground : MonoBehaviour
{
    public GameObject backgroundPref;
    public float gridScale;

    private GameObject[,] gridObjs;
    private Vector3 camPos;
    private Vector3 center;

    void Start()
    {
        gridObjs = new GameObject[5, 5];
        for(int i = 0; i < gridObjs.GetLength(0); i++)
        {
            for(int j = 0; j < gridObjs.GetLength(1); j++)
            {
                GameObject inst = GameObject.Instantiate(backgroundPref,transform.position,transform.rotation);
                inst.transform.position = inst.transform.position + new Vector3(gridScale * i, gridScale * j, transform.position.z) - 
                    new Vector3(20*((int)gridObjs.GetLength(0)/2),20 * ((int)gridObjs.GetLength(0) / 2), 0);
                inst.transform.localScale = new Vector3(gridScale, gridScale, 1);
                inst.transform.parent = this.transform;
                print(i + " " + j);
                gridObjs[i, j] = inst;
            }
        }
    }

    void Update()
    {
        camPos = Camera.main.transform.position;
        center = transform.position;
        if(camPos.x > center.x + gridScale)
        {
            transform.position += new Vector3(gridScale, 0, 0);
        }
        if(camPos.x < center.x - gridScale)
        {
            transform.position += new Vector3(-gridScale, 0, 0);
        }
        if (camPos.y > center.y + gridScale)
        {
            transform.position += new Vector3(0, gridScale, 0);
        }
        if (camPos.y < center.y - gridScale)
        {
            transform.position += new Vector3(0,-gridScale, 0);
        }
    }
}
