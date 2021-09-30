using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField]
    public float speed;

    private Rigidbody2D powerUpRb;

    void Start()
    {
        powerUpRb = GetComponent<Rigidbody2D>();
        powerUpRb.velocity = new Vector2(0f, -speed);
    }

    private void FixedUpdate()
    {
        if (powerUpRb.position.y <= -6f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}

