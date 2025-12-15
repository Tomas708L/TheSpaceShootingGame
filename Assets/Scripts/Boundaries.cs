using UnityEngine;

public class Boudaries : MonoBehaviour
{
    private Camera mainCamera;
    private float halfWidth;
    private float halfHeight;

    void Start()
    {
        mainCamera = Camera.main;

        // Get camera bounds in world units
        halfHeight = mainCamera.orthographicSize;
        halfWidth = halfHeight * mainCamera.aspect;
    }

    void Update()
    {
        Vector3 position = transform.position;// The current position

        // Wrap horizontally
        if (position.x > halfWidth) position.x = -halfWidth;
        else if (position.x < -halfWidth) position.x = halfWidth;

        // Wrap vertically
        if (position.y > halfHeight) position.y = -halfHeight;
        else if (position.y < -halfHeight) position.y = halfHeight;

        transform.position = position;
    }
}
