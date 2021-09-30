using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] Enemies;
    public GameObject[] Asteroids;
    public GameObject[] PowerUps;

    //Inspector elements
    [Header("Spawn Enemies")]
    [SerializeField]
    public float enemyMaxSpawnTime = 9.0f;
    [SerializeField]
    public float enemyMinSpawnTime = 4.0f;
    [SerializeField]
    GameObject enemy;

    [Header("Spawn Power Ups")]
    [SerializeField]
    public float powerUpMaxSpawnTime = 8.0f;
    [SerializeField]
    public float powerUpMinSpawnTime = 6.0f;
    [SerializeField]
    GameObject powerUpPrefab;

    [Header("Spawn Asteroids")]
    [SerializeField]
    public float asteroidMaxSpawnTime = 6.0f;
    [SerializeField]
    public float asteroidMinSpawnTime = 3.0f;
    [SerializeField]
    GameObject asteroid;

    [Header("Camera")]
    [SerializeField]
    Camera camera;

    //Script Variables
    public float enemySpawnTime;
    public float deltaEnemySpawnTime;
    private float halfEnemyWidth;

    public float powerUpSpawnTime;
    public float deltaPowerUpSpawnTime = 0f;
    private float halfPowerUpWidth;

    public float asteroidSpawnTime;
    public float deltaAsteroidSpawnTime = 0f;
    private float halfAsteroidWidth;

    private Vector2 cameraXBounds;
    private Vector2 cameraYBounds;

    private void Start()
    {
        enemySpawnTime = Random.Range(enemyMinSpawnTime, enemyMaxSpawnTime);
        powerUpSpawnTime = Random.Range(powerUpMinSpawnTime, powerUpMaxSpawnTime);
        asteroidSpawnTime = Random.Range(asteroidMinSpawnTime, asteroidMaxSpawnTime);

        //Limit Camera
        cameraXBounds.x = camera.ViewportToWorldPoint(new Vector2(0,0)).x;
        cameraXBounds.y = camera.ViewportToWorldPoint(new Vector2(1,0)).x;
        cameraYBounds.x = camera.ViewportToWorldPoint(new Vector2(0,0)).y;
        cameraYBounds.y = camera.ViewportToWorldPoint(new Vector2(0,1)).y;
        //Limit Enemy
        halfEnemyWidth = enemy.GetComponent<SpriteRenderer>().bounds.size.x * 0.5f;
        halfPowerUpWidth = enemy.GetComponent<SpriteRenderer>().bounds.size.x * 0.5f;
        halfAsteroidWidth = enemy.GetComponent<SpriteRenderer>().bounds.size.x * 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemy();
        SpawnAsteroid();
        SpawnPowerUp();
    }
    private void SpawnEnemy()
    {
        deltaEnemySpawnTime += Time.deltaTime;

        //Time Comprobation
        if (deltaEnemySpawnTime >= enemySpawnTime)
        {
            Instantiate(enemy, new Vector2(Random.Range(cameraXBounds.x + halfEnemyWidth, cameraXBounds.y - halfEnemyWidth), cameraYBounds.y), Quaternion.identity);

            Debug.Log("Enemy Spawned");
            deltaEnemySpawnTime = 0;
            enemySpawnTime = Random.Range(enemyMinSpawnTime, enemyMaxSpawnTime);
        }
    }

    private void SpawnPowerUp()
    {
        deltaPowerUpSpawnTime += Time.deltaTime;

        //Time Comprobation
        if (deltaPowerUpSpawnTime >= powerUpSpawnTime)
        {
            Instantiate(powerUpPrefab, new Vector2(Random.Range(cameraXBounds.x + halfPowerUpWidth, cameraXBounds.y - halfPowerUpWidth), cameraYBounds.y), Quaternion.identity);

            deltaPowerUpSpawnTime = 0;
            powerUpSpawnTime = Random.Range(powerUpMinSpawnTime, powerUpMaxSpawnTime);
        }
    }
    private void SpawnAsteroid()
    {
        deltaAsteroidSpawnTime += Time.deltaTime;

        //Time Comprobation
        if (deltaAsteroidSpawnTime >= asteroidSpawnTime)
        {
            Debug.Log("Asteroid Spawned");
            deltaAsteroidSpawnTime = 0;
            asteroidSpawnTime = Random.Range(asteroidMinSpawnTime, asteroidMaxSpawnTime);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(new Vector3(cameraXBounds.x, cameraYBounds.y, 0f), 1);
    }
}