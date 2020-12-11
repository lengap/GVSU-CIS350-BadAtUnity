using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System.Security.Cryptography;

//controls graphics for shotgun enemy
public class ShotgunEnemyGFX : MonoBehaviour
{
    // Start is called before the first frame update
    public AIPath aiPath;


    // Update is called once per frame
    //updates grpahics transformation based on current location of shotgun enemy
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
