using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Shield : MonoBehaviour
{ 
    public float time;
    private float timeStore;
    private bool shieldActive;



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
            if (time > 0)
            {
                time -= Time.deltaTime;
            }
            else
            {
                shieldActive = false;
                
                time = timeStore;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Player player = hitInfo.GetComponent<Player>();
        if (player != null)
        {
            shieldActive = true;
            player.activateShield();
        }

        Destroy(gameObject);
    }
}
