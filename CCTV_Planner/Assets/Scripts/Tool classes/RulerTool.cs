using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class RulerTool : Tool
{
    public GameObject rulerGO;
    public LineRenderer rulerRenderer;
    public TextMeshPro textObj;
    public Transform[] markers;
    private Vector2 startPos;
    private bool rulering;
    private bool visible;

    public RulerTool() : base() { }
    public override void start() {
        if(rulerGO.activeSelf)
            rulerGO.SetActive(false);
        rulering = false;
        visible = true;
    }
    public override void update() {
        if (Input.GetMouseButtonDown(0) && ToolbarManager.MouseOverObject() == null)
        {
            rulering = true;
            if (!visible)
            {
                activateAll();
            }

            startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rulerRenderer.SetPosition(0, new Vector3(startPos.x,startPos.y, 0));
            markers[0].position = new Vector3(startPos.x, startPos.y, 0);
        }
        if (Input.GetMouseButton(0) && rulering && ToolbarManager.MouseOverObject() == null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rulerRenderer.SetPosition(1, new Vector3(mousePos.x, mousePos.y, 0));
            markers[1].position = new Vector3(mousePos.x, mousePos.y, 0);

            float distance = Vector3.Distance(rulerRenderer.GetPosition(0), rulerRenderer.GetPosition(1));
            textObj.text = distance.ToString("f2") + "m";
            Vector3 middle = (rulerRenderer.GetPosition(0) + rulerRenderer.GetPosition(1))*0.5f;
            textObj.transform.position = middle;

        }
        if (Input.GetMouseButtonUp(0))
        {
            rulering = false;
            //rulerRenderer.enabled = false;
            //textObj.gameObject.SetActive(false);
        }
    }

    void deactivateAll()
    {
        rulerRenderer.enabled = false;
        textObj.gameObject.SetActive(false);
        markers[0].gameObject.SetActive(false);
        markers[1].gameObject.SetActive(false);
        visible = false;
    }

    void activateAll()
    {
        rulerRenderer.enabled = true;
        textObj.gameObject.SetActive(true);
        markers[0].gameObject.SetActive(true);
        markers[1].gameObject.SetActive(true);
        visible = true;
    }


    public override void selectTool()
    {
        rulerGO.SetActive(true);
        if (visible)
        {
            deactivateAll();
        }
    }
    public override void deselectTool()
    {
        rulerGO.SetActive(false);
    }
}
