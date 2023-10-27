using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ToolbarManager))]
public class ToolbarManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {

        if (GUILayout.Button("Reset tool list"))
        {
            ToolbarManager manager = (ToolbarManager)target;
            manager.tools = new Tool[] {
                new MoveTool(),
                new ZoomTool(),
                new RulerTool(),
                new SelectionTool(),
                new CreateObjectTool()
            };
            manager.tools[0].toolName = "Move";
            manager.tools[1].toolName = "Zoom";
            manager.tools[2].toolName = "Ruler";
            manager.tools[3].toolName = "Select";
            manager.tools[4].toolName = "CreateObject";
        }
        if(GUILayout.Button("Add script tools"))
        {
            Tool[] newTools = new Tool[] { new CreateObjectTool() };
            newTools[0].toolName = "CreateObject";
            addTools(newTools);
        }
        base.OnInspectorGUI();
    }
    void addTools(Tool[] newTools)
    {
        ToolbarManager manager = (ToolbarManager)target;
        Tool[] tools = new Tool[manager.tools.Length + newTools.Length];
        for(int i = 0; i< manager.tools.Length; i++)
        {
            tools[i] = manager.tools[i];
        }
        for(int i = 0; i < newTools.Length; i++)
        {
            tools[i+manager.tools.Length] = newTools[i];
        }
        manager.tools = tools;

    }
}
