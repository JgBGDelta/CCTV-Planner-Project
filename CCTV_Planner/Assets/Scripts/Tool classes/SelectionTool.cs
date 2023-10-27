using UnityEngine;

[System.Serializable]
public class SelectionTool : Tool
{
    [HideInInspector]
    public GameObject selectedGO;

    public float timeForDrag = 0.5f;
    private float mouseHoldTime = 0;
    private bool holding = false;

    private bool dragging = false;
    private Vector2 holdOffset;

    public SelectionTool() : base() { }
    public override void start()
    {

    }
    public override void update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            holding = true;
            deselectSelectedGO();
            GameObject obj = mouseOverObject();
            if (obj != null && obj.CompareTag("Object"))
            {
                obj.GetComponent<SpriteRenderer>().material.SetInt("_Outline", 1);
                selectedGO = obj;
            }
        }
        if (Input.GetMouseButton(0))
        {
            if (holding)
            {
                mouseHoldTime += Time.deltaTime;
            }
            if(mouseHoldTime >= timeForDrag && selectedGO != null && mouseOverObject() == selectedGO)
            {
                dragging = true;
                holding = false;
                mouseHoldTime = 0;
                holdOffset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - selectedGO.transform.position;
            }
            if (dragging)
            {
                selectedGO.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - holdOffset;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            holding = false;
            dragging = false;
            mouseHoldTime = 0;
        }
    }

    GameObject mouseOverObject()
    {
        Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(clickPosition, Vector2.zero);

        if (hit.collider != null && hit.collider.CompareTag("Object"))
        {
            return hit.collider.gameObject;
        }
        return null;
    } 

    void deselectSelectedGO()
    {
        if (selectedGO != null)
        {
            selectedGO.GetComponent<SpriteRenderer>().material.SetInt("_Outline", 0);
            selectedGO = null;
        }
    }

    public override void selectTool()
    {
        Debug.Log("Select tool selected");
        deselectSelectedGO();
    }
    public override void deselectTool()
    {
        deselectSelectedGO();
    }
}
