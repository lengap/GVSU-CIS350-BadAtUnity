using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//item class
public class Item : MonoBehaviour
{
    
	//if player touches item, destroy object and heal player
	void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other.name);
        if (other.CompareTag("Player")) {
            DestroyItem();
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.HealDamage(20);
            }
        }
		
		
		
    }

    //destroys game object
    void DestroyItem() {
        Destroy(gameObject);
    }
	
	
}
