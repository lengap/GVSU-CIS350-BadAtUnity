using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform FirePoint; //This is where the bullet is created
    public GameObject bulletPrefab; //prefab for the bullet sprite and physics

    // Update is called once per frame
    void Update()
    {

        //Can change fire input in "Project input settings"
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        
    }

    void Shoot()
    {
        //shooting logic
        Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
    }
}
