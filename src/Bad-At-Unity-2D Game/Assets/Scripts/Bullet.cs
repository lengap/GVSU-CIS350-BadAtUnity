using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EnemyAI enemy = hitInfo.GetComponent<EnemyAI>();
		ShotgunEnemyAI Shotgunner = hitInfo.GetComponent<ShotgunEnemyAI>();
        EnemySpawner spawner = hitInfo.GetComponent<EnemySpawner>();
        if(enemy != null)
        {
            enemy.TakeDamage(50);
        }
		if(Shotgunner != null)
        {
            Shotgunner.TakeDamage(50);
        }
        if (spawner != null)
        {
            spawner.TakeDamage(50);
        }

        Destroy(gameObject);
    }
}
