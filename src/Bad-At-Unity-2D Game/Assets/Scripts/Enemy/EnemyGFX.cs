using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System.Security.Cryptography;

//Class handles graphics for the enemy object
public class EnemyGFX : MonoBehaviour
{
    //AI pathing
    public AIPath aiPath;


    // Update is called once per frame
    //update method makes enemy animation follow position of enemy objet
    void Update()
    {
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f) {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
