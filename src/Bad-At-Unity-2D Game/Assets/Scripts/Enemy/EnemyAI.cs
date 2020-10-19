using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed;
    public float stopDist;
    public float retreatDist;

    private Transform player;

    private float timeBtwShots;
    public float startTimeBtwShots;
    public Transform FirePoint;

    public GameObject projectile;

    public int health = 100;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) > stopDist)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stopDist && Vector2.Distance(transform.position, player.position) > retreatDist)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDist) {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        if (timeBtwShots <= 0)
        {

            Instantiate(projectile, FirePoint.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;

        }
        else {
            timeBtwShots -= Time.deltaTime;
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
        //add death animation
        Destroy(gameObject);
    }
}
