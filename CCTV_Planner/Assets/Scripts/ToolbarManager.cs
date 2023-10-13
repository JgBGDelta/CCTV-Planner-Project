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
    private Tool selectedTool;


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

        //Initialize tools
        foreach (Tool tool in tools)
        {
            tool.start();
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
        if(selectedTool!= null)
            selectedTool.update();
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
        selectTool("-2,0");
    }

    public void selectTool(string parseableStr)
    {
        //Get toolId in the toolbar and toolListId in the global list of tools
        int[] tempResults = getIntsFromParseableString(parseableStr);
        int toolbarToolId = tempResults[0];
        int toolListId = tempResults[1];

        if (!canSelectTool(toolbarToolId) || (toolListId == SelectedToolId))
            return;


        toolbarSelectionSquares[SelectedToolbarId].gameObject.SetActive(!(toolbarToolId < 0));
        auxToolbarSelectionSquare.gameObject.SetActive(toolbarToolId < 0);

        if (toolbarToolId < 0)
        {
            auxToolbarSelectionSquare.localPosition = auxToolbarGameobject.transform.GetChild(toolbarToolId + 3).localPosition;
        }
        else
        {
            toolbarSelectionSquares[SelectedToolbarId].localPosition = toolbarsGameobjects[SelectedToolbarId].transform.GetChild(toolbarToolId + 1).localPosition;
        }

        //Select the tool from the list
        SelectedToolId = toolListId;
        if(selectedTool != null)
            selectedTool.deselectTool();
        selectedTool = tools[SelectedToolId];
        selectedTool.selectTool();
        

    }

    private int[] getIntsFromParseableString (string str)
    {
        string[] numsStr = str.Split(",");
        int[] nums = new int[numsStr.Length];
        for(int i = 0; i< numsStr.Length; i++)
        {
            nums[i] = int.Parse(numsStr[i]);
        }
        return nums;
    }

  
}
