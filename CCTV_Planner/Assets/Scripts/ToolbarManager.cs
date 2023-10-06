using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ToolbarManager : MonoBehaviour
{
    public int SelectedToolId { get; set; }
    public int SelectedToolbarId { get; set; }

    //Selection
    public GameObject[] toolbarsGameobjects;
    private RectTransform[] toolbarSelectionSquares;


    void Awake()
    {
        //Llena el array con los cuadrados de selección
        toolbarSelectionSquares = new RectTransform[toolbarsGameobjects.Length];
        for(int i = 0; i< toolbarsGameobjects.Length;i++){
            toolbarSelectionSquares[i] = toolbarsGameobjects[i].transform.GetChild(0).GetComponent<RectTransform>();
            toolbarSelectionSquares[i].gameObject.SetActive(true);
        }
    }
    private void Start()
    {
        SelectedToolbarId = -1;
        StartCoroutine(SelectToolbarFirstTime());
    }
    IEnumerator SelectToolbarFirstTime()
    {
        yield return new WaitForEndOfFrame();
        selectToolbar(0);
    }

    void Update()
    {
        
    }

    bool canSelectTool(int id)
    {
        //Implement later
        return true;
    }
    
    bool canSelectToolbar(int id)
    {
        //Implement later
        return true;
    }

    public void selectToolbar(int toolbarId)
    {
        if (!canSelectToolbar(toolbarId) || SelectedToolbarId == toolbarId)
            return;
        
        for(int i = 0; i< toolbarsGameobjects.Length; i++)
        {
            if (i != toolbarId)
            {
                toolbarsGameobjects[i].SetActive(false);
            }
        }
        toolbarsGameobjects[toolbarId].SetActive(true);
        SelectedToolbarId = toolbarId;
        selectTool(0);
    }

    public void selectTool(int toolId)
    {
        if (!canSelectTool(toolId))
            return;

        SelectedToolId = toolId;
        toolbarSelectionSquares[SelectedToolbarId].localPosition = toolbarsGameobjects[SelectedToolbarId].transform.GetChild(SelectedToolId+1).localPosition;

        switch (toolId)
        {
            case 0:
                //Move tool
                Camera.main.GetComponent<CameraControls>().selectMoveTool();
                break;
            case 1:
                //Zoom
                Camera.main.GetComponent<CameraControls>().selectZoomTool();
                break;
        }
    }
}
