using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    [SerializeField]
    private float bulletSpawnTime;
    private float bulletCurrentTime = 0f;

    [SerializeField]
    private GameObject playerBullet;

    [SerializeField]
    private GameObject[] bulletOrigin;
    
    private float speed;
    Rigidbody2D playerBulletRb;

    void Start()
    {
        playerBulletRb = GetComponent<Rigidbody2D>();
        playerBulletRb.velocity = new Vector2(0f, speed);  
    }

    void Update()
    {
        Shoot();
    }

    private void Shoot() { 
       
    }
}
