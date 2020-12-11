using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Weapon is class that allows player to shoot
//weapon is instantiated with player and handles shooting logic
public class Weapon : MonoBehaviour
{
    public Transform FirePoint; //This is where the bullet is created
    public GameObject bulletPrefab; //prefab for the bullet sprite and physics
    public Animator animator; //initializes animator for shooting animation
    public Player player;
    public bool activeShotgun;

    public GameObject SGBullet1;
    public GameObject SGBullet2;
    public GameObject SGBullet3;

    // Update is called once per frame

    //weapon is instantiated with regular properties
    void Start()
    {
        activeShotgun = false;
    }

    void Update()
    {
        //Player player = other.GetComponent<Player>();

        //Can change fire input in "Project input settings"
        //If player is able to shoot, and if pressed the "fire1"/Spacebar, then shoot
        if (Input.GetButtonDown("Fire1") && player.canShoot == true)//&& player.emptyBattery
        {
            //if conditions, then fire weapon
            Shoot();
            animator.SetBool("Shooting", true);
            FindObjectOfType<AudioManager>().Play("PlayerShoot");

        } else
        {
            animator.SetBool("Shooting", false);
        }
        
    }

    //function is called when player is shooting.  Instatiates bullets based on if powerup is equipped or not
    void Shoot()
    {
        //shooting logic
        if (activeShotgun == false)
        {
            //regular gun
            Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
        }

        else
        {
            //shotgun
            Instantiate(SGBullet1, FirePoint.position, FirePoint.rotation);
            Instantiate(SGBullet2, FirePoint.position, FirePoint.rotation);
            Instantiate(SGBullet3, FirePoint.position, FirePoint.rotation);
        }
    }
}
