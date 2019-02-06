using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public List<GameObject> EnemyList;
    // Start is called before the first frame update
    void Start()
    {
        
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
    }
}
