using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//landmines are placed around level and explode if player walked over it
public class Landmine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //if player walks on landmine, damage player and destroy landmine
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Player player = hitInfo.GetComponent<Player>();
        if(player != null)
        {
            player.TakeDamage(10);
        }
		
        Destroy(gameObject);
    }
    
}
