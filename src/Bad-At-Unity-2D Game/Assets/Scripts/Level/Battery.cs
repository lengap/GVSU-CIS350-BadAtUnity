using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//battery object is player ammunition
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

    //if player picks up batter, increment battery level
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

    //destorys game object
    void DestroyItem()
    {
        Destroy(gameObject);
    }


}

