using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwSpawns = startTimeBtwSpawns;
    }

    // Update is called once per frame
    void Update()
    {
		if((Vector2.Distance(transform.position, player.position) <= playerDistance )){
			if (timeBtwSpawns <= 0)
			{
				Instantiate(EnemyType[Random.Range(0,2)], SpawnPoint.position, Quaternion.identity);
				Debug.Log(enemyCnt);
				timeBtwSpawns = startTimeBtwSpawns;
			}
			else {
				timeBtwSpawns -= Time.deltaTime;
			}
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
