using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//script is for the final bossroom
public class BossRoom : MonoBehaviour
{
	
	private int bossCnt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		bossCnt = GameObject.FindGameObjectsWithTag("Boss").Length;
		Debug.Log(bossCnt);
		
        //if boss is killed, player wins the game (load victory scene)
		if(bossCnt == 0){
			SceneManager.LoadScene("Victory");
		}
		
        
    }
}
