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
                ShootAh();
            }
        }
        else if (collision.collider.CompareTag("EnemyBullet"))
        {
            EnemyBulletHit.Invoke();
            ShootAh();
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
        pickedNumber = Random.Range(0, ThingsThatCanShoot.Count -1);
        GameObject newBullet = Instantiate(EnemyBulletHolder,ThingsThatCanShoot[pickedNumber].transform.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().velocity = Vector2.down * 20;
    }
}
