using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	
	
	public int health;
	public int ammo;
   
       public void PlayGame()
    {
        //load next level
		PlayerPrefs.SetInt("PlayerCurrHealth", health);
		PlayerPrefs.SetInt("PlayerCurrAmmo", ammo);
        SceneManager.LoadScene("Level");
		SceneManager.SetActiveScene(SceneManager.GetSceneByName("Level"));
    }

    public void QuitGame()
    {
        Debug.Log("User quit game");
        Application.Quit();
    }
    
}
