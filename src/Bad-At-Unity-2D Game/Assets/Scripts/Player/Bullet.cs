using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    public int damage;
    public int startDamage;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        startDamage = damage;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EnemyAI enemy = hitInfo.GetComponent<EnemyAI>();
		ShotgunEnemyAI Shotgunner = hitInfo.GetComponent<ShotgunEnemyAI>();
        EnemySpawner spawner = hitInfo.GetComponent<EnemySpawner>();
        EnemyTransport transport = hitInfo.GetComponent<EnemyTransport>();
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
        Instantiate(impactEffect, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}
