using UnityEngine;
using System.Collections.Generic;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public int startingAsteroids = 3;     // Start with 3 asteroids
    public float spawnRangeX = 8f;
    public float spawnRangeY = 5f;
    public float increaseInterval = 20f;  // Increase max asteroids every 20 seconds

    private int maxAsteroids;
    private float timer = 0f;
    private List<GameObject> asteroids = new List<GameObject>();

    void Start()
    {
        maxAsteroids = startingAsteroids;

        // Spawn initial asteroids
        for (int i = 0; i < maxAsteroids; i++)
        {
            SpawnAsteroid();
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        // Increase max asteroids every 20 seconds
        if (timer >= increaseInterval)
        {
            maxAsteroids += 1;
            timer = 0f;
        }

        // Clean up destroyed asteroids from the list
        asteroids.RemoveAll(a => a == null);

        // Spawn new asteroids if below max
        while (asteroids.Count < maxAsteroids)
        {
            SpawnAsteroid();
        }
    }

    void SpawnAsteroid()
    {
        Vector2 spawnPos = new Vector2(Random.Range(-spawnRangeX, spawnRangeX),
                                       Random.Range(-spawnRangeY, spawnRangeY));

        GameObject newAsteroid = Instantiate(asteroidPrefab, spawnPos, Quaternion.identity);
        asteroids.Add(newAsteroid);
    }
}
