using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

//BOTTOM LEFT BULLET

public class berP7 : MonoBehaviour {

    //this is the projectile aimed at the player

    public float speed;
    public int damage;

    private Transform player;
    private Vector2 target;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //rb.velocity = transform.right * -speed;
        //rb.Velocity = new Vector2(-1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        transform.position = Vector2.MoveTowards(transform.position, target, speed * (Time.deltaTime/10));

        if (transform.position.x == target.x && transform.position.y == target.y) {
            DestroyProjectile();
        }
        */
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(-1, -1);
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other.name);
        if (other.CompareTag("Player")) {
            DestroyProjectile();
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                
                player.TakeDamage(damage);
            }
        }
    }

    void DestroyProjectile() {
        Destroy(gameObject);
    }



}
