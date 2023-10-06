using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public bool canMove = true;
    public bool canZoom = true;

    //Move with keys
    [field: SerializeField] public bool SmoothMovement { get; set; } = true;
    [field:SerializeField] public float PanSpeed { get; set; } = 1.0f;
    [field:SerializeField] public string HorizontalAxisName { get; set; } = "Horizontal";
    [field:SerializeField] public string VerticalAxisName { get; set; } = "Vertical";

    //Move by dragging
    public bool moveToolSelected { get; set; } = false;
    private Vector2 origin;
    private Vector2 difference;
    private Vector2 resetCamera;
    private bool moveDrag = false;

    //Zoom
    private float initialZoom;
    private float zoom;
    [field: SerializeField] public float zoomMultiplier { get; set; } = 8f;
    [field: SerializeField] public float maxZoom { get; set; } = 8f;
    [field: SerializeField] public float minZoom { get; set; } = 2f;
    private float velocity = 0f;
    [field: SerializeField] public float smoothTime { get; set; } = 0.25f;

    //Zoom by dragging
    public bool zoomToolSelected { get; set; } = false;
    public float zoomMultiplierDragging = 1f;
    private Vector2 zoomOrigin;
    private float zoomDifferenceHeight;
    private bool zoomDrag = false;


    private Camera _camera;

    private void Start()
    {
        _camera = GetComponent<Camera>();
        zoom = _camera.orthographicSize;
        initialZoom = _camera.orthographicSize;
        resetCamera = _camera.transform.position;
    }


    void LateUpdate()
    {
        if (canMove)
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
        if (canZoom)
        {
            float input = Input.GetAxis("Mouse ScrollWheel");
            zoom -= input * zoomMultiplier;
            zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
            _camera.orthographicSize = Mathf.SmoothDamp(_camera.orthographicSize, zoom, ref velocity, smoothTime);
        }
        if (moveToolSelected)
        {
            if (Input.GetMouseButton(0))
            {
                difference = _camera.ScreenToWorldPoint(Input.mousePosition) - _camera.transform.position;
                if (!moveDrag)
                {
                    moveDrag = true;
                    origin = _camera.ScreenToWorldPoint(Input.mousePosition);
                }
            }
            else
            {
                moveDrag = false;
            }
            if (moveDrag)
            {
                _camera.transform.position = origin - difference;
            }
        }
        if (zoomToolSelected)
        {
            if (Input.GetMouseButton(0))
            {
                if (!zoomDrag)
                {
                    zoomDrag = true;
                    origin = Input.mousePosition;
                }
                zoomDifferenceHeight = ((Vector2)Input.mousePosition - origin).y;
            }
            else
            {
                zoomDrag = false;
            }
            if (zoomDrag)
            {
                zoom -= zoomDifferenceHeight * zoomMultiplierDragging;
                zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
                _camera.orthographicSize = Mathf.SmoothDamp(_camera.orthographicSize, zoom, ref velocity, smoothTime);
            }
        }
        //Clamp camera depth at -10
        _camera.transform.position = new Vector3(_camera.transform.position.x, _camera.transform.position.y, -10);
    }

    public void ResetCamera()
    {
        _camera.transform.position = resetCamera;
        _camera.orthographicSize = initialZoom;
    }
}
