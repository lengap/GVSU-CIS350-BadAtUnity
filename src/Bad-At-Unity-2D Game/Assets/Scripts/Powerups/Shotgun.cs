using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Shotgun : MonoBehaviour
{ 
    public float time;
    private float timeStore;
    private bool shotgunActive;
    public Weapon weapon;


    // Start is called before the first frame update
    void Start()
    {
        timeStore = time;
        shotgunActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (shotgunActive == true)
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
            }
            else
            {
                shotgunActive = false;
                
                time = timeStore;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Player player = hitInfo.GetComponent<Player>();
        if (player != null)
        {
            shotgunActive = true;
            weapon.activeShotgun = true;
        }

        Destroy(gameObject);
    }
}
