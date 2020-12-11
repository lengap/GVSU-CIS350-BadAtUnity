using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

//Enemy spawner object is where enemies spawn in the game
public class EnemySpawner : MonoBehaviour
{
    public float playerDistance;
    public int health = 100;
    public Transform player;
    public Transform SpawnPoint;
    public GameObject[] EnemyType;
    private float timeBtwSpawns;
	private int enemyCnt = 0;
    public float startTimeBtwSpawns;


    // Start is called before the first frame update
    //Spawner finds player object
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwSpawns = startTimeBtwSpawns;
    }

    // Update is called once per frame
    //Checks to see if player is within a certain distance, and it is time to spawsn
    void Update()
    {
       //if player is close enough
		if((Vector2.Distance(transform.position, player.position) <= playerDistance )){
            //if enough time has passed, instantiate a new enemy object
			if (timeBtwSpawns <= 0)
			{
				Instantiate(EnemyType[Random.Range(0,2)], SpawnPoint.position, Quaternion.identity);
				Debug.Log(enemyCnt);
				timeBtwSpawns = startTimeBtwSpawns;
			}
            //if not time to spawn new enemy, decrease time to new enemy spawning
			else {
				timeBtwSpawns -= Time.deltaTime;
			}
		}
    }

    //Function decreases health of spawner object
    public void TakeDamage(int damage) {
        health -= damage;
        //If health of spawner is below zero, destroy the game object
        if (health <= 0) {

            Destroy();
        
        }
    }

    //Funcion destroys the gameobject
    void Destroy() {
        Destroy(gameObject);    
    }
}
