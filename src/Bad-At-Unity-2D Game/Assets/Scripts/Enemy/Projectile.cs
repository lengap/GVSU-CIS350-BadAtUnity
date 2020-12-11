using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

//enemy projectile is what the enemy fires
public class Projectile : MonoBehaviour {

    public float speed;
    public int damage;
    public GameObject impactEffect;
    private Transform player;
    private Vector2 target;

    // Start is called before the first frame update
    //when bullet is instantiated (enemy shoots) it finds the player game object and moves towards it's position
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target= new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * (Time.deltaTime/10));

        if (transform.position.x == target.x && transform.position.y == target.y) {
            DestroyProjectile();
        }
    }

    //When bullet impacts collider/another game object
    void OnTriggerEnter2D(Collider2D other) {
        
        //create impact effect
        Instantiate(impactEffect, transform.position, transform.rotation);

        //damage player if hit
        Debug.Log(other.name);
        if (other.CompareTag("Player")) {
            DestroyProjectile();
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                
                player.TakeDamage(20);
            }
        }
    }

    //Function called to destroy projectile after impact is made
    void DestroyProjectile() {
        Destroy(gameObject);
    }



}
