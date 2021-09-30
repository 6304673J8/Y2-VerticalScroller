using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    /*private float boundariesY = -6.0f;

    private float spawnBoundariesMaxX = 3.26f;
    private float spawnBoundariesMinX = -3.26f;*/

    public float speed;

    private Rigidbody2D enemyRb;
    public int hp = 3;

    private void Awake()
    {
        Vector3 Scaler = transform.localScale;
        Scaler.y *= -1;
        transform.localScale = Scaler;
    }

    // Start is called before the first frame update
    void Start()
    { 
        enemyRb = GetComponent<Rigidbody2D>();
        enemyRb.velocity = new Vector2(0f, -speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            hp--;
            if(hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void FixedUpdate()
    {
        if (enemyRb.position.y <= -6f)
        {
            Destroy(gameObject);
        }
    }
}
