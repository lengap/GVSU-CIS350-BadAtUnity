using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

//Right Bullet

public class SGBullet2 : MonoBehaviour {

   

    public float speed;
    public int damage;
    public Player player;
    public GameObject impactEffect;


    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (player.facingRight == true)
        {
            rb.velocity = new Vector2(1, 0);
        }

        else
        {
            rb.velocity = new Vector2(-1, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EnemyAI enemy = hitInfo.GetComponent<EnemyAI>();
        ShotgunEnemyAI Shotgunner = hitInfo.GetComponent<ShotgunEnemyAI>();
        EnemySpawner spawner = hitInfo.GetComponent<EnemySpawner>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        if (Shotgunner != null)
        {
            Shotgunner.TakeDamage(damage);
        }
        if (spawner != null)
        {
            spawner.TakeDamage(damage);
        }
        Instantiate(impactEffect, transform.position, transform.rotation);

        Destroy(gameObject);
    }



}
