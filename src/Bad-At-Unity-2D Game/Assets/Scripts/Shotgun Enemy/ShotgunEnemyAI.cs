using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

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
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        if ((player.transform.position.x > gameObject.transform.position.x) && !facingRight)
        {
            Flip();
        }
        if ((player.transform.position.x < gameObject.transform.position.x) && facingRight)
        {
            Flip();
        }

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
    
    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 tmpScale = gameObject.transform.localScale;
        tmpScale.x *= -1;
        gameObject.transform.localScale = tmpScale;
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
