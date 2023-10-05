using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ToolbarManager : MonoBehaviour
{
    private int selectedToolId;

    //Selection
    public RectTransform selectedToolSquare;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    bool canSelectTool(int id)
    {
        return true;
    }

    public void selectTool(int id)
    {
        if (!canSelectTool(id))
        {
            return;
        }
        selectedToolId = id;
        print("Selected");
        selectedToolSquare.localPosition = new Vector3(50, -4.64f - selectedToolId * 89.35f, 0); //Hardcoded values
    }
}
