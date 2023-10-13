using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ZoomTool : Tool
{

    public ZoomTool() : base()
    {

    }

    public override void selectTool()
    {
        Camera.main.GetComponent<CameraControls>().zoomToolSelected = true;
    }
    public override void deselectTool()
    {
        Camera.main.GetComponent<CameraControls>().zoomToolSelected = false;
    }
}
