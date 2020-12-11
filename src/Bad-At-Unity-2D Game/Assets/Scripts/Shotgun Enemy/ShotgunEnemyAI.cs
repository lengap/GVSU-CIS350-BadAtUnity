using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

//script for the shotgun e=nemy game object
public class ShotgunEnemyAI : MonoBehaviour
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

    public GameObject projectile1;
    public GameObject projectile2;
    public GameObject projectile3;
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
    //each frame make decision on movement
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

        //if time to shoot, instantiate 3 projectiles 
        if (timeBtwShots <= 0)
        {

            //each projectile object is the same, but different transformations in order to simulate spread
            FindObjectOfType<AudioManager>().Play("ShotgunShoot");
            Instantiate(projectile1, FirePoint.position, Quaternion.identity);
            Instantiate(projectile2, FirePoint.position, Quaternion.identity);
            Instantiate(projectile3, FirePoint.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;

        }
 
        else {
            timeBtwShots -= Time.deltaTime;
        }



    }
    
    //flips direction enemy is facing
    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 tmpScale = gameObject.transform.localScale;
        tmpScale.x *= -1;
        gameObject.transform.localScale = tmpScale;
    }

    //lowers health of enemy if hit
    public void TakeDamage( int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Die();
        }
    }

    //destorys enemy if dead
    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
