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

    public RulerTool() : base() { }
    public override void start() {
        if(rulerGO.activeSelf)
            rulerGO.SetActive(false);
    }
    public override void update() {
        if (Input.GetMouseButtonDown(0))
        {
            rulerRenderer.enabled = true;
            textObj.gameObject.SetActive(true);

            startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rulerRenderer.SetPosition(0, new Vector3(startPos.x,startPos.y, 0));
            markers[0].position = new Vector3(startPos.x, startPos.y, 0);
        }
        if (Input.GetMouseButton(0))
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
            //rulerRenderer.enabled = false;
            //textObj.gameObject.SetActive(false);
        }
    }

    public override void selectTool()
    {
        rulerGO.SetActive(true);
        rulerRenderer.enabled = false;
        textObj.gameObject.SetActive(false);
    }
    public override void deselectTool()
    {
        rulerGO.SetActive(false);
    }
}
