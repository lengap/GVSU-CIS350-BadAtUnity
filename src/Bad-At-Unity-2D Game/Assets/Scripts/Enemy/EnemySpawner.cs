using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float playerDistance;
    public int health = 100;
    public Transform player;
    public Transform SpawnPoint;
    public GameObject[] EnemyType;
    private float timeBtwSpawns;
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
        if ((Vector2.Distance(transform.position, player.position) <= playerDistance ) && timeBtwSpawns <= 0)
        {
            Instantiate(EnemyType[Random.Range(0,3)], SpawnPoint.position, Quaternion.identity);
            timeBtwSpawns = startTimeBtwSpawns;
        }
        else {
            timeBtwSpawns -= Time.deltaTime;
        }
    }

    public void TakeDamage(int damage) {
        health -= damage;
        if (health <= 0) {

            Destroy();
        
        }
    }

    void Destroy() {
        Destroy(gameObject);    
    }
}
