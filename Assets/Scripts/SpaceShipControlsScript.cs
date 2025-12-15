using UnityEngine;
using UnityEngine.InputSystem;

public class SpaceshipController2D : MonoBehaviour
{
    public float rotationSpeed = 200f;  // degrees per second
    public float thrustForce = 5f;      // acceleration
    public float maxSpeed = 10f;        // cap for velocity
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 0.25f;

    private float nextFireTime;


    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the rigidbody component
    }

    void Update()
    {
        // Rotation
        float rotationInput = 0f;
        if (Keyboard.current.aKey.isPressed) rotationInput = 1f;   // Rotate left
        if (Keyboard.current.dKey.isPressed) rotationInput = -1f;  // Rotate right

        transform.Rotate(0, 0, rotationInput * rotationSpeed * Time.deltaTime);

        // Thrust
        if (Keyboard.current.wKey.isPressed)
        {
            Vector2 force = transform.up * thrustForce;
            rb.AddForce(force);
        }

        // Limit max speed
        rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity, maxSpeed);

        // Shooting
        if (Keyboard.current.spaceKey.wasPressedThisFrame && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }



        
    }
    void Shoot()
    {
    Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);// Create bullet at fire point
    }
    void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Asteroid"))// Check for collision with asteroid
    {
        GameManager.instance.GameOver();
    }
}


}
