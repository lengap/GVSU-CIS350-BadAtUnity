using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room_Loader : MonoBehaviour
{
	
	private int spnrCnt = 0;
	private HealthBar healthbar;
	
	
    // Start is called before the first frame update
    void Start()
    {
        //SceneManager.LoadSceneAsync("Testing");
    }

    // Update is called once per frame
    void Update()
    {
		spnrCnt = GameObject.FindGameObjectsWithTag("Spawner").Length;
		Debug.Log("Spawner Count " + spnrCnt);
		
		if(spnrCnt == 0 && SceneManager.GetActiveScene().name == "Level"){
			SceneManager.LoadScene("BossRoom");
			SceneManager.UnloadScene("Level");
		}
		
    }
	
	void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other.name);
        if (other.CompareTag("Player")) {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
				if(SceneManager.GetActiveScene().name != "Level"){
					SceneManager.LoadScene("Level");
					SceneManager.SetActiveScene(SceneManager.GetSceneByName("Level"));
					SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
					
					Destroy(gameObject);
				}
				else if (SceneManager.GetActiveScene().name == "Level"){
					int rand = Random.Range(0,3);
					if(rand == 0){
						SceneManager.LoadScene("Bedroom");
						SceneManager.SetActiveScene(SceneManager.GetSceneByName("Bedroom"));
						SceneManager.UnloadSceneAsync("Level");
					}
					if(rand == 1){
						SceneManager.LoadScene("Office");
						SceneManager.SetActiveScene(SceneManager.GetSceneByName("Office"));
						SceneManager.UnloadSceneAsync("Level");
					}
					if(rand == 2){
						SceneManager.LoadScene("Library");
						SceneManager.SetActiveScene(SceneManager.GetSceneByName("Library"));
						SceneManager.UnloadSceneAsync("Level");
					}
					
				}
            }
        }
		
    }
	
}
