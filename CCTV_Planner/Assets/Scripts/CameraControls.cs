using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    private bool moveToolSelected;
    private bool zoomToolSelected;

    [field: SerializeField] public bool SmoothMovement { get; set; } = true;
    [field:SerializeField] public float PanSpeed { get; set; } = 1.0f;
    [field:SerializeField] public string HorizontalAxisName { get; set; } = "Horizontal";
    [field:SerializeField] public string VerticalAxisName { get; set; } = "Vertical";
    private Camera _camera;

    private void Start()
    {
        _camera = GetComponent<Camera>();
    }

    public void selectMoveTool(){ moveToolSelected = true; }
    public void selectZoomTool() { zoomToolSelected = true; }

    void LateUpdate()
    {
        if (moveToolSelected)
        {
            Vector2 inputVector;
            if (SmoothMovement)
            {
                inputVector = new Vector2(
                Input.GetAxis(HorizontalAxisName),
                Input.GetAxis(VerticalAxisName)
                );
            }
            else
            {
                inputVector = new Vector2(
                Input.GetAxisRaw(HorizontalAxisName),
                Input.GetAxisRaw(VerticalAxisName)
                );
            }
            _camera.transform.Translate(inputVector * PanSpeed * Time.deltaTime);
        }
        if (zoomToolSelected)
        {
            Vector2 inputVector;
            if (SmoothMovement)
            {
                inputVector = new Vector2(
                Input.GetAxis(HorizontalAxisName),
                Input.GetAxis(VerticalAxisName)
                );
            }
            else
            {
                inputVector = new Vector2(
                Input.GetAxisRaw(HorizontalAxisName),
                Input.GetAxisRaw(VerticalAxisName)
                );
            }
            _camera.transform.Translate(inputVector * PanSpeed * Time.deltaTime);
        }
    }
}
