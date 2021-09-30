using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProMovement : MonoBehaviour
{
    private float direction;

    [Header("Bullets")]
    [SerializeField]
    private float bulletSpawnTime;
    private float bulletCurrentTime = 0f;

    [SerializeField]
    private GameObject playerBullet;

    [SerializeField]
    private GameObject[] bulletOrigins;

    [Header("Camera")]
    [SerializeField]
    Camera camara;
    private Vector2 cameraXBounds;

    private Rigidbody2D playerRigidBody;
    private Vector2 desiredMovement = Vector2.zero;
    private float playerSpriteWidth;

    private Rigidbody2D shipRb;

    [Header("Stats")]
    [SerializeField]
    private float speed = 10;
    public float maxSpeed = 8;
    private float powerUpMaxDuration = 10f;
    private float powerUpCurrentTime = 0f;

    //bullets
    public float bulletPosition;
    public GameObject bulletPrefab;
    private float randInt;
    // Start is called before the first frame update
    void Start()
    {
        shipRb = GetComponent<Rigidbody2D>();
        cameraXBounds.x = camara.ViewportToWorldPoint(new Vector2(0f, 1f)).x;
        cameraXBounds.y = camara.ViewportToWorldPoint(new Vector2(1f, 1f)).x;

        playerSpriteWidth = GetComponent<SpriteRenderer>().bounds.size.x * 0.5f;
    }

    // Update is called once per frame
    private void Update()
    {
        desiredMovement = new Vector2(Input.GetAxis("Horizontal"), 0f);

        Shoot();
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

    private void Shoot()
    {
        //Increase spawn time
        bulletCurrentTime += Time.deltaTime;

        if (bulletCurrentTime >= bulletSpawnTime) {
            bulletCurrentTime = 0f;

            for (int i = 0; i < bulletOrigins.Length; i++)
            {
                Instantiate(playerBullet, bulletOrigins[i].transform.position, Quaternion.identity);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "PowerUp")
        {
            StartCoroutine(PowerUp());
        }
    }
    IEnumerator PowerUp()
    {
        powerUpCurrentTime += Time.deltaTime;

        if (Random.Range(0f, 1f) >= 0.5f)
        {
            speed *= 2f;
            yield return new WaitForSeconds(10);
            speed *= 0.5f;
        }
        else
        {
            bulletSpawnTime *= 0.5f;
            yield return new WaitForSeconds(10);
            bulletSpawnTime *= 2f;
        }
    }
}