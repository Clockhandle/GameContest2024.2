using UnityEngine;

public class DraggingPins : MonoBehaviour
{
    public Vector3 movementAxis = new Vector3(1, 1, 0).normalized; // Define the movement axis (e.g., diagonal)
    private Vector3 previousMousePosition;
    private bool isDragging = false;
    public LayerMask pinLayer;
    public Camera mainCamera; // Explicitly assign the correct camera in the Inspector

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main; // Fallback to the default main camera
        }

        UpdateMovementAxis(); // Calculate movement axis based on rotation at start
    }

    void Update()
    {
        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f; // Keep it in 2D

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero, Mathf.Infinity, pinLayer);
            if (hit.collider != null && hit.collider.gameObject == gameObject) // Ensure this is the clicked pin
            {
                isDragging = true;
                previousMousePosition = mouseWorldPos;
            }
        }

        if (isDragging)
        {
            Vector3 mouseDelta = mouseWorldPos - previousMousePosition;

            // Project mouse movement onto the defined movement axis
            Vector3 projectedMovement = Vector3.Project(mouseDelta, movementAxis) / 2;

            // Move only the clicked object
            transform.position += projectedMovement;

            previousMousePosition = mouseWorldPos; // Update previous position
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
    }

    void UpdateMovementAxis()
    {
        float angleRad = transform.eulerAngles.z * Mathf.Deg2Rad; // Convert Z rotation to radians
        movementAxis = new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad), 0f).normalized;
    }
}
