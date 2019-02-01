using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShishir : MonoBehaviour
{
    public GameObject PlayerBullet;

    [SerializeField]
    private float bulletSpeed = 5f;

    [SerializeField]
    private float playerSpeed = 5f;


    [SerializeField]
    private Rigidbody2D playerRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
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
        if(!GameObject.FindGameObjectWithTag("PlayerBullet"))
        {
            GameObject bullet = Instantiate(PlayerBullet, this.transform.position + Vector3.up, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = Vector3.up * bulletSpeed;
        }
    }

    private void Move()
    {
        float movement = Input.GetAxisRaw("Horizontal");
        playerRigidBody.velocity = new Vector2(movement * playerSpeed, playerRigidBody.velocity.y);
    }
}
