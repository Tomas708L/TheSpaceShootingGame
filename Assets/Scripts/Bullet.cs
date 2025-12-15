using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 15f;
    public float lifetime = 2f;
    public GameObject explosionPrefab;

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.up * speed;  // linearVelocity → velocity
        Destroy(gameObject, lifetime);
    }

void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Asteroid"))
    {
        // Spawn explosion
        if (explosionPrefab != null)
        {
            GameObject explosion = Instantiate(explosionPrefab, other.transform.position, Quaternion.identity);
            explosion.transform.localScale = other.transform.localScale; // optional, matches asteroid size

            // Play particle system explicitly
            ParticleSystem ps = explosion.GetComponent<ParticleSystem>();
            if (ps != null)
            {
                ps.Play();
                Destroy(explosion, ps.main.duration + ps.main.startLifetime.constantMax);
            }
        }

        Destroy(other.gameObject);        // destroy asteroid
        Destroy(gameObject);              // destroy bullet
        ScoreManager.instance.AddPoints(1); // add score
    }
}

}
