using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float horizontal;
    private Rigidbody2D shipRb;
    public float impulse = 40;
    public float maxImpulse = 120;

    bool isMovingLeft = false;
    bool isMovingRight = false;

    //bullets
    public float bulletPosition;
    public GameObject bulletPrefab;

    void Start()
    {
        shipRb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        horizontal = InputController.Horizontal;
        if (Input.GetKey(KeyCode.A))
        {
            isMovingLeft = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            isMovingRight = true;
        }
        //Input.GetAxis("Horizontal");
        //Input.GetButtonDown()
    }
    private void FixedUpdate()
    {
        if (isMovingRight == true)
        {
            shipRb.AddForce(transform.right * impulse, ForceMode2D.Impulse);
        }
        else if (isMovingRight == false)
        {
            shipRb.AddForce(-transform.right * impulse, ForceMode2D.Impulse);
        }
    }
}
