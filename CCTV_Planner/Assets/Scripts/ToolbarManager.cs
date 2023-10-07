using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ToolbarManager : MonoBehaviour
{
    public int SelectedToolId { get; set; }
    public int SelectedToolbarId { get; set; }

    [Header("Tools")]
    [SerializeReference]
    public Tool[] tools;

    [Header("Toolbars")]
    public GameObject[] toolbarsGameobjects;
    public GameObject auxToolbarGameobject;
    private RectTransform auxToolbarSelectionSquare;
    private RectTransform[] toolbarSelectionSquares;


    void Awake()
    {
        //Llena el array con los cuadrados de selección
        toolbarSelectionSquares = new RectTransform[toolbarsGameobjects.Length];
        for(int i = 0; i< toolbarsGameobjects.Length;i++){
            toolbarSelectionSquares[i] = toolbarsGameobjects[i].transform.GetChild(0).GetComponent<RectTransform>();
        }
        auxToolbarSelectionSquare = auxToolbarGameobject.transform.GetChild(0).GetComponent<RectTransform>();

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

        if (toolId < 0)
        {
            SelectedToolId = toolId;//-2 -> Move, -1 -> Zoom
            toolbarSelectionSquares[SelectedToolbarId].gameObject.SetActive(false);
            auxToolbarSelectionSquare.gameObject.SetActive(true);
            auxToolbarSelectionSquare.localPosition = auxToolbarGameobject.transform.GetChild(SelectedToolId + 3).localPosition;
        }
        else
        {
            SelectedToolId = toolId;
            toolbarSelectionSquares[SelectedToolbarId].gameObject.SetActive(true);
            auxToolbarSelectionSquare.gameObject.SetActive(false);
            toolbarSelectionSquares[SelectedToolbarId].localPosition = toolbarsGameobjects[SelectedToolbarId].transform.GetChild(SelectedToolId + 1).localPosition;
        }

        

    }

  
}
