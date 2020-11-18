using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class KamikazeAI : MonoBehaviour
{
    public float speed;
    public float stopDist;
    public float retreatDist;

    private Transform player;

    private float timeBtwShots;
    public float startTimeBtwShots;
    public Transform FirePoint;

    public GameObject projectile1;
    public GameObject projectile2;
    public GameObject projectile3;
    public GameObject deathEffect;

    public int health = 100;

    private int shotCount;
    private int startShotCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
        shotCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //if three shots have not been fired, move like normal
        if (shotCount < 3)
        {
            //if further than stop distance, move towards player
            if (Vector2.Distance(transform.position, player.position) > stopDist)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            //if further than stop and further than retreat
            else if (Vector2.Distance(transform.position, player.position) < stopDist && Vector2.Distance(transform.position, player.position) > retreatDist)
            {
                transform.position = this.transform.position;
            }
            else if (Vector2.Distance(transform.position, player.position) < retreatDist)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            }

        }

        //if three shots have been fired, and the next shot is not firing, move faster
        else if (shotCount == 3 && timeBtwShots > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, (speed + 2) * Time.deltaTime);
        }

        else
        {
            shotCount = 0;
        }

        //if time to shoot
        if (timeBtwShots <= 0)
        {
            

            Instantiate(projectile1, FirePoint.position, Quaternion.identity);
            Instantiate(projectile2, FirePoint.position, Quaternion.identity);
            Instantiate(projectile3, FirePoint.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
            shotCount++;
        }
        else {
            timeBtwShots -= Time.deltaTime;
        }



    }

    //if kamikaze runs into player (melee attack)- 50 damage
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {

                player.TakeDamage(50);
            }
        }
    }

    public void TakeDamage( int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
