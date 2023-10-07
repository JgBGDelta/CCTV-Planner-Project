using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MoveTool : Tool
{

    public MoveTool() : base()
    {

    }

    public override void selectTool()
    {
        Camera.main.GetComponent<CameraControls>().moveToolSelected = true;
    }
    public override void deselectTool()
    {
        Camera.main.GetComponent<CameraControls>().moveToolSelected = false;
    }
}
