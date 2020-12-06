﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        if (other.CompareTag("Player"))
        {
            DestroyItem();
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.incBattery();
            }
        }



    }

    void DestroyItem()
    {
        Destroy(gameObject);
    }


}
