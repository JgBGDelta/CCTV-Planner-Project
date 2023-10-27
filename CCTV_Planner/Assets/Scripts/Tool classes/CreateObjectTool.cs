using UnityEngine;

[System.Serializable]
public class CreateObjectTool : Tool
{
    public int SelectedObjectId{ get; set; }
    public GameObject[] prefabs;
    public Transform objectsParent;

    public CreateObjectTool() : base() { }
    public override void start() { }
    public override void update() 
    {
        if (Input.GetMouseButtonDown(0) && Manager.MouseOverObject() == null)
        {
            Vector2 mousePosOnWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GameObject newObject = GameObject.Instantiate(prefabs[SelectedObjectId], mousePosOnWorld, Quaternion.identity,objectsParent);
            newObject.tag = "Object";
        }
        if (Input.GetMouseButton(0) && Manager.MouseOverObject() == null)
        {

        }
        if (Input.GetMouseButtonUp(0) && Manager.MouseOverObject() == null)
        {

        }
    }
    public override void selectTool() { }
    public override void deselectTool() { }
}
