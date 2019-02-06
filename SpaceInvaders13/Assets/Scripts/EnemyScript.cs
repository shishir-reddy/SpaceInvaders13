using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject EnemyBullet;
    private Rigidbody2D m_rigidbody;
    public int speed;
    public bool canShoot;
    // Start is called before the first frame update
    void Awake()
    {
        
    }
    void Start()
    {
        canShoot = false;
        m_rigidbody = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        m_rigidbody.velocity = new Vector2(speed * Time.deltaTime, 0);

    }
}
