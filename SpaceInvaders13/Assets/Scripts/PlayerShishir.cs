using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerShishir : MonoBehaviour
{
    public GameObject PlayerBullet;

    public static PlayerShishir instance;

    [SerializeField]
    private float bulletSpeed = 5f;

    [SerializeField]
    private float playerSpeed = 5f;

    private Rigidbody2D playerRigidBody;

    public UnityEvent OnHitPlayer;
    private Camera c;

    private void Awake()
    {
        playerRigidBody = this.GetComponent<Rigidbody2D>();
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        c = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

        Move();
    }

    /*Instantiate a bullet 1 unit above the player
     * Set the bulle tto travel upwards
     * 
     */
    private void Shoot()
    {
        if (!GameObject.FindGameObjectWithTag("PlayerBullet"))
        {
            GameObject bullet = Instantiate(PlayerBullet, this.transform.position + Vector3.up, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = Vector3.up * bulletSpeed;
        }
    }

    private void Move()
    {
        //float movement = Input.GetAxisRaw("Horizontal");
        //playerRigidBody.velocity = new Vector2(movement * playerSpeed, playerRigidBody.velocity.y);
        
        if (Input.GetKey(KeyCode.D))
        {
            if (c.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x > transform.position.x + transform.localScale.x/2 ) 
            {
                playerRigidBody.velocity = new Vector2(playerSpeed , playerRigidBody.velocity.y);
            }
            else
            {
                playerRigidBody.velocity = new Vector2(0 , playerRigidBody.velocity.y);
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (c.ScreenToWorldPoint(new Vector2(0, 0)).x < transform.position.x - transform.localScale.x/2 ) 
            {
                playerRigidBody.velocity = new Vector2(-playerSpeed , playerRigidBody.velocity.y);
            }
            else
            {
                playerRigidBody.velocity = new Vector2(0,0);
            }
        }
        else
        {
            playerRigidBody.velocity = new Vector2(0,0);
        }  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet"))
        {
            OnHitPlayer.Invoke();
            Destroy(collision.gameObject);
            EnemyController.instance.ShootAh();
        }
    }
}
