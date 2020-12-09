using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

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
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwSpawns = startTimeBtwSpawns;
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
            animator.SetBool("IsMoving", true);
        }
        else if (Vector2.Distance(transform.position, player.position) < stopDist && Vector2.Distance(transform.position, player.position) > retreatDist)
        {
            transform.position = this.transform.position;
            animator.SetBool("IsMoving", false);
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDist)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            animator.SetBool("IsMoving", true);
        }

        if ((Vector2.Distance(transform.position, player.position) <= playerDistance))
        {
            if (timeBtwSpawns <= 0)
            {
                Instantiate(EnemyType[Random.Range(0, 2)], SpawnPoint.position, Quaternion.identity);
                Debug.Log(enemyCnt);
                timeBtwSpawns = startTimeBtwSpawns;
            }
            else
            {
                timeBtwSpawns -= Time.deltaTime;
            }
        }
        

        if (timeBtwShots <= 0)
        {
           // FindObjectOfType<AudioManager>().Play("RobotShoot");
            Instantiate(projectile, FirePoint.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;

        }
        else
        {
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
    public void TakeDamage(int damage) {
        health -= damage;
        if (health <= 0) {

            Destroy();
        
        }
    }

    void Destroy() {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);    
    }
}
