using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed;
    public int damage;

    private Transform player;
    private Vector2 target;

    // Start is called before the first frame update
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

    void OnTriggerEnter2D(Collider2D other) {
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

    void DestroyProjectile() {
        Destroy(gameObject);
    }



}
