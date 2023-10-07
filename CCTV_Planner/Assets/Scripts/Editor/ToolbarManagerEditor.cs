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
                new ZoomTool()
            };
            manager.tools[0].toolName = "Move";
            manager.tools[1].toolName = "Zoom";

        }
        base.OnInspectorGUI();
    }
}
