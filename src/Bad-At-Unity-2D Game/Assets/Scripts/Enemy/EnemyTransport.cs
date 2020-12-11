using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

//Enemy transport is the boss in the game.  Functions basically as an enemy spawner that moves and shoots
public class EnemyTransport : MonoBehaviour
{
    public float playerDistance;
    public int health = 100;
    public Transform player;

  
    public float speed;
    public float stopDist;
    public float retreatDist;


    private float timeBtwShots;
    public float startTimeBtwShots;
    public Transform FirePoint;
    public Transform SpawnPoint;


    public GameObject projectile;
    public GameObject deathEffect;
    public Animator animator;

    public bool facingRight = false;
    private float horizontal;
    private float vertical;


    public GameObject[] EnemyType;
    private float timeBtwSpawns;
    private int enemyCnt = 0;
    public float startTimeBtwSpawns;




    // Start is called before the first frame update
    //Find player position
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwSpawns = startTimeBtwSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        //controls flipping of the object
        if ((player.transform.position.x > gameObject.transform.position.x) && !facingRight)
        {
            Flip();
        }
        if ((player.transform.position.x < gameObject.transform.position.x) && facingRight)
        {
            Flip();
        }
        //if far enough from player, move towards player
        if (Vector2.Distance(transform.position, player.position) > stopDist)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            animator.SetBool("IsMoving", true);
        }
        //if further than the retreat distance, stop moving
        else if (Vector2.Distance(transform.position, player.position) < stopDist && Vector2.Distance(transform.position, player.position) > retreatDist)
        {
            transform.position = this.transform.position;
            animator.SetBool("IsMoving", false);
        }
        //if closer than the retreat distance to the player, run awasy from player
        else if (Vector2.Distance(transform.position, player.position) < retreatDist)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            animator.SetBool("IsMoving", true);
        }

        //if player distance is close enough to player
        if ((Vector2.Distance(transform.position, player.position) <= playerDistance))
        {
            //if time to spawn , spawn new enemy
            if (timeBtwSpawns <= 0)
            {
                Instantiate(EnemyType[Random.Range(0, 2)], SpawnPoint.position, Quaternion.identity);
                Debug.Log(enemyCnt);
                timeBtwSpawns = startTimeBtwSpawns;
            }
            //if not time to spawn enemy, decrease time to next spawn
            else
            {
                timeBtwSpawns -= Time.deltaTime;
            }
        }
        
        //if time to shoot, instantitate new bullet
        if (timeBtwShots <= 0)
        {
           // FindObjectOfType<AudioManager>().Play("RobotShoot");
            Instantiate(projectile, FirePoint.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;

        }
        //if not time to shoot, decrease time to next shot
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
    
    //Flips object direction
    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 tmpScale = gameObject.transform.localScale;
        tmpScale.x *= -1;
        gameObject.transform.localScale = tmpScale;
    }

    //Function decreases health of transport
    public void TakeDamage(int damage) {
        health -= damage;
        //if health is below zero, destroy the game object
        if (health <= 0) {

            Destroy();
        
        }
    }

    //Function destroys game object
    void Destroy() {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);    
    }
}
