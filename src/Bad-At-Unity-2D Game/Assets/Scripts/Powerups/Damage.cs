using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//script for damage powerup
public class Damage : MonoBehaviour
{ 
    public float time;
    private float timeStore;
    private bool damageActive;
    public Bullet bullet;



    // Start is called before the first frame update
    void Start()
    {
        timeStore = time;
        damageActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if powerup is active, increase damage and start timer
        if (damageActive == true)
        {


            if (time > 0)
            {
                time -= Time.deltaTime;
            }
            else
            {
                damageActive = false;
                bullet.damage = bullet.startDamage;
                time = timeStore;
            }
        }
    }

    //if player picks up powerup, activiate powerup
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Player player = hitInfo.GetComponent<Player>();
        if (player != null)
        {
            damageActive = true;
            bullet.damage = bullet.damage * 2;
        }

        Destroy(gameObject);
    }
}
