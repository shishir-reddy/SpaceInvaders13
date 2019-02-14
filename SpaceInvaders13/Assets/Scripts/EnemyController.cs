using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    public GameObject EnemyBulletHolder;
    public List<GameObject> EnemyList;
    private List<GameObject> ThingsThatCanShoot;


    private int pickedNumber;


    private void Awake()
    {
        EnemyScript.instance.OnEnemyKilled.AddListener(KillEnemyInList);
    }


    // Start is called before the first frame update
    void Start()
    {
        ThingsThatCanShoot = new List<GameObject>();
        ShootAh();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*
     * Called when an enemy hits the GameManager. Reverses x velocity and moves each enemy down by 1.
     */
    private void UpdateMovement()
    {
        for (int i = 0; i < EnemyList.Count; i++)
        {
            Rigidbody2D enemyRigidBody = EnemyList[i].GetComponent<Rigidbody2D>();

            enemyRigidBody.position = new Vector2(enemyRigidBody.position.x, enemyRigidBody.position.y - 1);
            enemyRigidBody.velocity = new Vector2(-1 * enemyRigidBody.velocity.x, enemyRigidBody.velocity.y);
        }
    }


    void KillEnemyInList(GameObject theEnemy)
    {
        EnemyList.Remove(theEnemy);
        Destroy(theEnemy);
    }


    /*
     * Called when an enemy bullet disappears. Updates which enemies can shoot.
     */
    private void UpdateShooters()
    {
        for (int i = 0; i < EnemyList.Count; i++)
        {
            EnemyScript enemy = EnemyList[i].GetComponent<EnemyScript>();
            enemy.CheckifCanShoot();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().CompareTag("Enemy"))
        {
            UpdateMovement();
        }

        if (collision.GetComponent<Collider2D>().CompareTag("EnemyBullet"))
        {
            Debug.Log("Bullet Hit");
            Destroy(collision.gameObject);
            ShootAh();
        }
    }
    void ShootAh()
    {
        UpdateShooters();
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
            GameObject newBullet = Instantiate(EnemyBulletHolder, transform, Quaternion.identity);
            newBullet.GetComponent<Rigidbody2D>().velocity = Vector2.down * 2;
            Physics2D.IgnoreCollision(ThingsThatCanShoot[pickedNumber].GetComponent<Collider2D>(), newBullet.GetComponent<Collider2D>());
        }
        ThingsThatCanShoot.Clear();
    }





}
