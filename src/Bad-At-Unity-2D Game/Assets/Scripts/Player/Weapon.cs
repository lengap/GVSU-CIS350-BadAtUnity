using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()
    {
        activeShotgun = false;
    }

    void Update()
    {
        //Player player = other.GetComponent<Player>();

        //Can change fire input in "Project input settings"
        if (Input.GetButtonDown("Fire1"))//&& player.emptyBattery
        {
            Shoot();
            animator.SetBool("Shooting", true);
        } else
        {
            animator.SetBool("Shooting", false);
        }
        
    }

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
