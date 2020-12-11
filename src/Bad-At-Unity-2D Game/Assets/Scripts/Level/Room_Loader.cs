using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room_Loader : MonoBehaviour
{
	
	private int spnrCnt = 0;
	private bool OnBoss = true;
	
	
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
		Debug.Log("OnBoss " + OnBoss);
		
		if(spnrCnt == 0 && SceneManager.GetActiveScene().name == "Level"){
			SceneManager.LoadScene("BossRoom");
		}
		
    }
	
    //if player runs into ladder, change the game scene
	void OnTriggerEnter2D(Collider2D other) {
		OnBoss = false;
        Debug.Log(other.name);
        if (other.CompareTag("Player")) {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
				if(SceneManager.GetActiveScene().name != "Level"){
					SceneManager.LoadScene("Level");
					Debug.Log(SceneManager.GetActiveScene().name);
					OnBoss = true;
					
					Destroy(gameObject);
				}
				else if (SceneManager.GetActiveScene().name == "Level"){
					int rand = Random.Range(0,3);
					if(rand == 0){
						OnBoss = false;
						SceneManager.LoadScene("Bedroom");
						Debug.Log(SceneManager.GetActiveScene().name);
						
					}
					if(rand == 1){
						OnBoss = false;
						SceneManager.LoadScene("Office");
						Debug.Log(SceneManager.GetActiveScene().name);
						
					}
					if(rand == 2){
						OnBoss = false;
						SceneManager.LoadScene("Library");
						Debug.Log(SceneManager.GetActiveScene().name);
						
					}
					
				}
            }
        }
		
    }
	
}
