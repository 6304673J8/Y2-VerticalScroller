using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    /*[SerializeField]
    private float bulletSpawnTime;
    private float bulletCurrentTime = 0f;
    */

    [SerializeField]
    private float speed;
    Rigidbody2D playerBulletRb;

    void Start()
    {
        playerBulletRb = GetComponent<Rigidbody2D>();
        playerBulletRb.velocity = new Vector2(0f, speed);  
    }

    private void FixedUpdate()
    {
        if (playerBulletRb.position.y >= 5.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
