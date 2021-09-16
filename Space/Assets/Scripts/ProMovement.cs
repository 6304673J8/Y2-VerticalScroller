using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProMovement : MonoBehaviour
{
    private float direction;

    [SerializeField]
    Camera camara;
    private Vector2 cameraXBounds;

    private Rigidbody2D playerRigidBody;
    private Vector2 desiredMovement = Vector2.zero;
    private float playerSpriteWidth;

    private Rigidbody2D shipRb;

    [SerializeField]
    private float speed = 10;
    public float maxSpeed = 8;

    //bullets
    public float bulletPosition;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        shipRb = GetComponent<Rigidbody2D>();
        cameraXBounds.x = camara.ViewportToWorldPoint(new Vector2(0f, 1f)).x;
        cameraXBounds.y = camara.ViewportToWorldPoint(new Vector2(1f, 1f)).x;

        playerSpriteWidth = GetComponent<SpriteRenderer>().bounds.size.x * 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        desiredMovement = new Vector2(Input.GetAxis("Horizontal"), 0f);
    }

    private void FixedUpdate()
    {
        MoveCharacter(desiredMovement);
    }

    private void MoveCharacter(Vector2 direction)
    {
        float finalPositionX = transform.position.x + (direction.x * speed * Time.fixedDeltaTime);

        finalPositionX = Mathf.Clamp(finalPositionX, cameraXBounds.x + playerSpriteWidth, cameraXBounds.y - playerSpriteWidth);
        shipRb.MovePosition(new Vector2(finalPositionX, shipRb.position.y));

        /*if (isMovingRight == true)
        {
            shipRb.MovePosition(new Vector2(finalPositionX, shipRb.position.y));
            if (shipRb.velocity.magnitude > maxSpeed)
            {
                shipRb.velocity = shipRb.velocity.normalized * maxSpeed;
            }
        }
        else if (isMovingLeft == true)
        {
            shipRb.AddForce(-transform.right * speed, ForceMode2D.Impulse);
            if (shipRb.velocity.magnitude > maxSpeed)
            {
                shipRb.velocity = shipRb.velocity.normalized * maxSpeed;
            }
        }*/
    }
}
