using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//main menu class handles logic of the main menu
public class MainMenu : MonoBehaviour
{
	
	
	public int health;
	public int ammo;
	
	public void Start(){
		
	}
    
	//Starts game once play game button is pressed
	public void PlayGame()
    {
        //load next level
		PlayerPrefs.SetInt("PlayerCurrHealth", health);
		PlayerPrefs.SetInt("PlayerCurrAmmo", ammo);
        SceneManager.LoadSceneAsync("Level");
		Debug.Log(SceneManager.GetActiveScene().name);
    }

    //if player quits game, quit the application
    public void QuitGame()
    {
        Debug.Log("User quit game");
        Application.Quit();
    }
    
}
