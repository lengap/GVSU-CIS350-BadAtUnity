using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room_Loader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //SceneManager.LoadSceneAsync("Testing");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other.name);
        if (other.CompareTag("Player")) {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
				if(SceneManager.GetActiveScene().name == "RoomTest"){
					SceneManager.LoadScene("Level");
					SceneManager.UnloadScene("RoomTest");
					
					Destroy(gameObject);
				}
				else if (SceneManager.GetActiveScene().name == "Level"){
					SceneManager.LoadScene("RoomTest");
					SceneManager.UnloadScene("Level");
				}
            }
        }
		
    }
	
}
