using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script handles pausing of the game
public class Pause : MonoBehaviour
{

    public bool gamePaused = false;
    public GameObject pauseMenu;


    // Update is called once per frame
    //timescale paused is 0.  timescale normally is 1
    void Update()
    {
        //if player hits escape pause game
        if (Input.GetButtonDown("Cancel"))
        {
            if (gamePaused == false)
            {
                //timescale is set to 0, essentially freezes game 
                Time.timeScale = 0;
                gamePaused = true;
                Cursor.visible = true;
                pauseMenu.SetActive(true);
            }


            else
            {
                pauseMenu.SetActive(false);
                gamePaused = false;
                Cursor.visible = false;
                Time.timeScale = 1;
            }
        }
    }
}
