using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject EnemyBullet;
    private Rigidbody2D m_rigidbody;
    public int speed;
    public bool canShoot;
    RaycastHit ThingInFront;
    // Start is called before the first frame update
    void Awake()
    {
        
        m_rigidbody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        m_rigidbody.velocity = new Vector2(speed * Time.deltaTime, 0);
    }

    public void CheckifCanShoot()
    {
        if (canShoot)
            return;
        if (Physics.Raycast(transform.position, -Vector3.down * 5, out ThingInFront))
        {
            Debug.Log("This hit a Thing");
            if (ThingInFront.collider.CompareTag("Enemy"))
            {
                canShoot = false;
            }
            else
            {
                canShoot = true;
            }
        }
        else { canShoot = true; }
    }
}
