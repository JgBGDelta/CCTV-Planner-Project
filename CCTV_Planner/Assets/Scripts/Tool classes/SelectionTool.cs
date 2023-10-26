using UnityEngine;

[System.Serializable]
public class SelectionTool : Tool
{
    public GameObject selectedGO;

    public SelectionTool() : base() { }
    public override void start()
    {

    }
    public override void update()
    {
        if (Input.GetMouseButtonDown(0))
        {

        }
        if (Input.GetMouseButton(0))
        {

        }
        if (Input.GetMouseButtonUp(0))
        {

        }
    }

    public override void selectTool()
    {

    }
    public override void deselectTool()
    {

    }
}
