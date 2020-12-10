using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
		
		if(bossCnt == 0){
			SceneManager.LoadScene("Victory");
		}
		
        
    }
}
