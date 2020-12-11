using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

//Enemy AI controls enemy moving and shooting
public class EnemyAI : MonoBehaviour
{
    public Animator animator;
    public float speed;

    //variables to control Enemy behavior
    public float stopDist;
    public float retreatDist;

    private Transform player;

    private float timeBtwShots;
    public float startTimeBtwShots;
    public Transform FirePoint;
    public bool facingRight = false;
    public float prevPositionX;


    public GameObject projectile;
    public GameObject deathEffect;

    public int health = 100;

    public string shootNoise;


    // Start is called before the first frame update
    //When enemy is instantiated, it finds the player object
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        //controls direction enemy faces
        if ((player.transform.position.x > gameObject.transform.position.x)&& !facingRight)
        {
            Flip();
        }
        //controls direction enemy faces
        if ((player.transform.position.x < gameObject.transform.position.x) && facingRight)
        {
            Flip();
        }

        //If enemy is not closer than stop distance, move towards the player
        if (Vector2.Distance(transform.position, player.position) > stopDist)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            animator.SetBool("isRunning", true);
        }
        //If enemy is far enough and close enough to player, stop moving towards player
        else if (Vector2.Distance(transform.position, player.position) < stopDist && Vector2.Distance(transform.position, player.position) > retreatDist)
        {
            transform.position = this.transform.position;
            animator.SetBool("isRunning", false);
        }
        //if enemy is within retreat distance to player, then move away from player
        else if (Vector2.Distance(transform.position, player.position) < retreatDist) {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            animator.SetBool("isRunning", true);
        }

        //if enough time has passed, shoot
        if (timeBtwShots <= 0)
        {
            //shoot
            //instantiates enemy projectile (enemy's bullet)
            Instantiate(projectile, FirePoint.position, Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("EnemyShoot");
            timeBtwShots = startTimeBtwShots;

        }
        //if not time to shoot, reduce time to next shot fired
        else {
            timeBtwShots -= Time.deltaTime;
        }

    }

    
    //Function flips direciton that the enemy faces
    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 tmpScale = gameObject.transform.localScale;
        tmpScale.x *= -1;
        gameObject.transform.localScale = tmpScale;
    }

    //Function decreases enemy health based on damage amount
    public void TakeDamage( int damage)
    {
        health -= damage;

        //If enemy's health is below zero, they die
        if(health <= 0)
        {
            Die();
        }
    }

    //Function destroys enemy game object, is called when enemy health is below zero
    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
