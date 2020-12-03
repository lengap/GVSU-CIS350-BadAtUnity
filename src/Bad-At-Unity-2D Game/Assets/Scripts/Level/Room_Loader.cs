using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room_Loader : MonoBehaviour
{
	
	private int spnrCnt = 0;
	private int health;
	
	
    // Start is called before the first frame update
    void Start()
    {
        //SceneManager.LoadSceneAsync("Testing");
    }

    // Update is called once per frame
    void Update()
    {
		spnrCnt = GameObject.FindGameObjectsWithTag("Spawner").Length;
		
		if(spnrCnt == 0){
			if(SceneManager.GetActiveScene().name == "BossRoom"){
				
			} else {
				SceneManager.LoadScene("BossRoom");
				SceneManager.UnloadSceneAsync("Level");
			}
		}
		
    }
	
	void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other.name);
        if (other.CompareTag("Player")) {
            Player player = other.GetComponent<Player>();
			health = player.getHealth();
			Debug.Log(health);
            if (player != null)
            {
				if(SceneManager.GetActiveScene().name != "Level"){
					SceneManager.LoadScene("Level");
					SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
					
					player.setHealth(health);
					
					Destroy(gameObject);
				}
				else if (SceneManager.GetActiveScene().name == "Level"){
					int rand = Random.Range(0,3);
					if(rand == 0){
						SceneManager.LoadScene("Bedroom");
						SceneManager.UnloadSceneAsync("Level");
						player.setHealth(health);
					}
					if(rand == 1){
						SceneManager.LoadScene("Office");
						SceneManager.UnloadSceneAsync("Level");
						player.setHealth(health);
					}
					if(rand == 2){
						SceneManager.LoadScene("Library");
						SceneManager.UnloadSceneAsync("Level");
						player.setHealth(health);
					}
					
				}
            }
        }
		
    }
	
	private void CheckNumSpawners(){
		
	}
	
}
