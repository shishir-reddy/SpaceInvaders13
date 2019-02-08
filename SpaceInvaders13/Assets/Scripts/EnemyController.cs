using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    public GameObject EnemyBulletHolder;
    public UnityEvent EnemyBulletHit;
    public List<GameObject> EnemyList;
    public List<GameObject> ThingsThatCanShoot;
    private int pickedNumber;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < EnemyList.Count; i++)
        {
            if (EnemyList[i].GetComponent<EnemyScript>().canShoot)
            {
                ThingsThatCanShoot.Add(EnemyList[i]);
            }
        }
        ShootAh();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            for (int i = 0; i<EnemyList.Count; i++)
            {
                GameObject controller = EnemyList[i];
                controller.GetComponent<EnemyScript>().speed = -controller.GetComponent<EnemyScript>().speed;
                controller.transform.position = new Vector3(controller.transform.position.x, controller.transform.position.y - .5f, 0);
            }
        }
        else if (collision.collider.CompareTag("EnemyBullet"))
        {
            Debug.Log("Bullet Hit");
            EnemyBulletHit.Invoke();
            ShootAh();
            Destroy(collision.collider);
        }
    }
    void ShootAh()
    {
        for (int i = 0; i < EnemyList.Count; i++)
        {
            if (EnemyList[i].GetComponent<EnemyScript>().canShoot)
            {
                ThingsThatCanShoot.Add(EnemyList[i]);
            }
        }
        if (ThingsThatCanShoot.Count > 0)
        {
            
            pickedNumber = Random.Range(0, ThingsThatCanShoot.Count - 1);
            Vector3 transform = new Vector3(ThingsThatCanShoot[pickedNumber].transform.position.x, ThingsThatCanShoot[pickedNumber].transform.position.y - 1, ThingsThatCanShoot[pickedNumber].transform.position.z);
            GameObject newBullet = Instantiate(EnemyBulletHolder, transform , Quaternion.identity);
            newBullet.GetComponent<Rigidbody2D>().velocity = Vector2.down * 2;
        }
    }
}
