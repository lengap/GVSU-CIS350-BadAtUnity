using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Simple class that containts information for the in game camera
public class CameraFollow : MonoBehaviour
{
    //target in this case would be the player
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //for each frame, update camera position based on the target (player)
    void Update()
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
    }
}
