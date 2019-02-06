using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShishir : MonoBehaviour
{
    public float speed = 2f;

    private Rigidbody2D enemyRigidBody;

    private void Awake()
    {
        enemyRigidBody = this.GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        enemyRigidBody.velocity = new Vector2(-1 * speed, enemyRigidBody.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Wall"))
        {
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Collider2D>().CompareTag("Wall"))
        {
            enemyRigidBody.position = new Vector2(enemyRigidBody.position.x, enemyRigidBody.position.y - 1);
            enemyRigidBody.velocity = new Vector2(-1 * enemyRigidBody.velocity.x, enemyRigidBody.velocity.y);
        }
    }
}
