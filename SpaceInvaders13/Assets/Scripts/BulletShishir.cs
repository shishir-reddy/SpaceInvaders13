﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShishir : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Collider2D>().CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        else if(collision.GetComponent<Collider2D>().CompareTag("Wall"))
        {
            Destroy(gameObject);
        }

        
    }
}
