using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class IntegerUnityEvent : UnityEvent<GameObject> { }

public class EnemyScript : MonoBehaviour
{
    public GameObject EnemyBullet;
    private Rigidbody2D m_rigidbody;
    public int speed;
    public bool canShoot;
    RaycastHit ThingInFront;
    
    public int PointValue;
    public static IntegerUnityEvent OnEnemyKilled = new IntegerUnityEvent();




    // Start is called before the first frame update
    void Awake()
    {
        canShoot = false;
        m_rigidbody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        m_rigidbody.velocity = new Vector2(speed, 0);
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void CheckifCanShoot()
    {

        if (canShoot)
        {
            return;
        }
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down * 5);
        if (hitInfo)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                canShoot = false;
            }
            else
            {
                canShoot = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("PlayerBullet"))
        {
            OnEnemyKilled.Invoke(this.gameObject);
        }
    }
}
