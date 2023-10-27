using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Manager : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public static GameObject MouseOverObject()
    {
        PointerEventData pointer = new PointerEventData(EventSystem.current);
        pointer.position = Input.mousePosition;
        List<RaycastResult> rayList = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointer, rayList);
        if (rayList.Count > 0)
        {
            return rayList[0].gameObject;
        }
        else
        {
            return null;
        }
    }
}
