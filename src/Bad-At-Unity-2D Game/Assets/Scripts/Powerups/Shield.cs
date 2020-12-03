using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Shield : MonoBehaviour
{ 
    public float time;
    private float timeStore;
    private bool shieldActive;
	
	private Player player;



    // Start is called before the first frame update
    void Start()
    {
        timeStore = time;
        shieldActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (shieldActive == true)
        {
            if (time < 0)
            {
				shieldActive = false;
				player.deactivateShield();
                
                time = timeStore;
            }
            else
            {
				Debug.Log(time);
                time -= Time.deltaTime;   
            }
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Player temp = hitInfo.GetComponent<Player>();
        if (temp != null)
        {
            shieldActive = true;
            temp.activateShield();
        }

        Destroy(gameObject);
    }
}
