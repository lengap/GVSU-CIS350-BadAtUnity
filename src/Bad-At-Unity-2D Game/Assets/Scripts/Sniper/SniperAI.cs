using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

//controls AI for sniper enemy
public class SniperAI : MonoBehaviour
{
    public Animator animator;
    public float speed;
    public float stopDist;
    public float retreatDist;

    private Transform player;

    private float timeBtwShots;
    public float startTimeBtwShots;
    public Transform FirePoint;
    public bool facingRight = false;

    public GameObject projectile;
    public GameObject deathEffect;

    public int health = 100;


    // Start is called before the first frame update
    //finds player position
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        //contols direction enemy faces
        if ((player.transform.position.x > gameObject.transform.position.x) && !facingRight)
        {
            Flip();
        }
        if ((player.transform.position.x < gameObject.transform.position.x) && facingRight)
        {
            Flip();
        }

        //if enemy further than stop distance, move towards player
        if (Vector2.Distance(transform.position, player.position) > stopDist)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            animator.SetBool("isRunning", true);
        }
        //if closer than stop distance and further than retreat distance, stop  moving

        else if (Vector2.Distance(transform.position, player.position) < stopDist && Vector2.Distance(transform.position, player.position) > retreatDist)
        {
            transform.position = this.transform.position;
            animator.SetBool("isRunning", false);
        }
        //if within retreat distance, move away from player

        else if (Vector2.Distance(transform.position, player.position) < retreatDist) {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            animator.SetBool("isRunning", true);
        }
        //if time to shoot, then shoot
        if (timeBtwShots <= 0)
        {
            //shoot
            Instantiate(projectile, FirePoint.position, Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("EnemyShoot");
            timeBtwShots = startTimeBtwShots;

        }
        else {
            timeBtwShots -= Time.deltaTime;
        }



    }

    //flips direction enemy faces 
    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 tmpScale = gameObject.transform.localScale;
        tmpScale.x *= -1;
        gameObject.transform.localScale = tmpScale;
    }

    //decreases health based on damage parameter
    public void TakeDamage( int damage)
    {
        health -= damage;

        //if health is below zero enemy dies
        if(health <= 0)
        {
            Die();
        }
    }

    //destroys game object
    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
