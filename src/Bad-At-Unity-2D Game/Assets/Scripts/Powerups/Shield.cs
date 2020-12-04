using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Shield : MonoBehaviour
{ 
    public float time;
    private float timer;
    private bool shieldActive;
	
	private Player player;



    // Start is called before the first frame update
    void Start()
    {
        timer = time;
        shieldActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (shieldActive == true)
        {
            if (timer < 0)
            {
				shieldActive = false;
                Debug.Log("SHIELD DEACTIVATED");
                player.deactivateShield();

                timer = time;
            }
            else
            {
				Debug.Log(timer);
                timer -= Time.deltaTime;   
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
            Debug.Log("SHIELD ACTIVE");
        }

        Destroy(gameObject);
    }
}
