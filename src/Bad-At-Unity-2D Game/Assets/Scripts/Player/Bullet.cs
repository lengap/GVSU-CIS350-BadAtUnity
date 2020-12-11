using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

//Player's main type of bullet.  Each bullet is it's own object that is instantiated when the player shoots
public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    public int damage;
    public int startDamage;

    // Start is called before the first frame update
    //When bullet is instantiated, it is immediately moving in direction it is directed 
    void Start()
    {
        rb.velocity = transform.right * speed;
        startDamage = damage;
    }

    //If bullet hits enemy, or spawner, then they take damage and bullet object is destroyed
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //getting hit info
        EnemyAI enemy = hitInfo.GetComponent<EnemyAI>();
		ShotgunEnemyAI Shotgunner = hitInfo.GetComponent<ShotgunEnemyAI>();
        EnemySpawner spawner = hitInfo.GetComponent<EnemySpawner>();
        EnemyTransport transport = hitInfo.GetComponent<EnemyTransport>();

        //checking type of enemy, and then damaging accordingly
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        if (transport != null)
        {
            transport.TakeDamage(damage);
        }
        if (Shotgunner != null)
        {
            Shotgunner.TakeDamage(damage);
        }
        if (spawner != null)
        {
            spawner.TakeDamage(damage);
        }

        //instantiate bullet impact effect
        Instantiate(impactEffect, transform.position, transform.rotation);

        //destroying bullet after contact is made with another game object
        Destroy(gameObject);
    }
}
