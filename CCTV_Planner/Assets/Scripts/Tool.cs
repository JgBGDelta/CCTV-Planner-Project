using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Tool
{
    public string toolName;
    public Tool() { }
    public abstract void selectTool();
    public abstract void deselectTool();

    public abstract void start();
    public abstract void update();
}

