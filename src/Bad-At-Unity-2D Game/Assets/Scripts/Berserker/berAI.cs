using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class berAI : MonoBehaviour
{
    public Animator animator;
    public float speed;
    public float stopDist;
    public float retreatDist;

    public GameObject deathEffect;

    private Transform player;

    private float timeBtwShots;
    public float startTimeBtwShots;
    public Transform FirePoint;

    public GameObject projectile1;
    public GameObject projectile2;
    public GameObject projectile3;
    public GameObject projectile4;
    public GameObject projectile5;
    public GameObject projectile6;
    public GameObject projectile7;
    public GameObject projectile8;

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
            animator.SetBool("isRunning", true);
        }
        else if (Vector2.Distance(transform.position, player.position) < stopDist && Vector2.Distance(transform.position, player.position) > retreatDist)
        {
            transform.position = this.transform.position;
            animator.SetBool("isRunning", false);
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDist) {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            animator.SetBool("isRunning", true);
        }

        if (timeBtwShots <= 0)
        {
            Instantiate(projectile1, FirePoint.position, Quaternion.identity);
            Instantiate(projectile2, FirePoint.position, Quaternion.identity);
            Instantiate(projectile3, FirePoint.position, Quaternion.identity);
            Instantiate(projectile4, FirePoint.position, Quaternion.identity);
            Instantiate(projectile5, FirePoint.position, Quaternion.identity);
            Instantiate(projectile6, FirePoint.position, Quaternion.identity);
            Instantiate(projectile7, FirePoint.position, Quaternion.identity);
            Instantiate(projectile8, FirePoint.position, Quaternion.identity);
            
            
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
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
