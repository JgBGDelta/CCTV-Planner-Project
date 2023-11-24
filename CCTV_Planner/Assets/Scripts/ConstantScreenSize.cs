using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantScreenSize : MonoBehaviour
{
    public bool isLineRenderer = false;
    public float tileScale = 1.0f;

    public float desiredSize = 1.0f;

    private Camera mainCamera;
    private LineRenderer lineRenderer;

    void Start()
    {
        mainCamera = Camera.main;
        if (!isLineRenderer)
            return;

        lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer == null)
        {
            Debug.LogError("LineRenderer component not found. Make sure your object has a LineRenderer.");
        }
    }

    void LateUpdate()
    {
        if (!isLineRenderer)
        {
            // Calculate the desired size in world units based on the screen height and camera's orthographic size
            float targetSize = desiredSize / mainCamera.pixelHeight * (175f * mainCamera.orthographicSize);

            // Set the scale of the sprite to match the desired size
            transform.localScale = new Vector3(targetSize, targetSize, 1f);
        }
        else
        {
            // Calculates the desired target size
            float targetSize = desiredSize / mainCamera.pixelHeight * (2f * mainCamera.orthographicSize);

            // Sets the size accordingly
            lineRenderer.startWidth = targetSize;
            lineRenderer.endWidth = targetSize;

            // Calculate the texture scale based on the desired size and the screen size
            float textureScale = desiredSize / targetSize * tileScale;

            // Set the texture scale on the LineRenderer's material
            lineRenderer.material.mainTextureScale = new Vector2(textureScale, 1f);
        }
    }
}
