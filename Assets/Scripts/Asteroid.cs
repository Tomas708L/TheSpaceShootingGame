using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float minSpeed = 0.5f;
    public float maxSpeed = 2f;
    public float maxRotationSpeed = 90f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Random movement direction
        Vector2 direction = Random.insideUnitCircle.normalized;

        // Random speed
        float speed = Random.Range(minSpeed, maxSpeed);

        rb.linearVelocity = direction * speed;

        // Random rotation
        rb.angularVelocity = Random.Range(-maxRotationSpeed, maxRotationSpeed);
    }
}
