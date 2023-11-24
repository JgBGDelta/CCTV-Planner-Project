using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppObject : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        if(gameObject.tag != "Object")
        {
            gameObject.tag = "Object";
        }
    }
}
