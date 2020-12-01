using UnityEngine.Audio;
using System;
using UnityEngine;


/*
 * -Audio manager is a game object that manages all sound in the game.
 * -The audio manager stores the sound files in use, and makes them easy to call throughout the game
 * -In order to play a sound, use : FindObjectOfType<AudioManager>().Play("Sound Name");
 * -Sounds can be easily added through the inspector of the AudioManager Object
 * -Sound script contains data for each sound
 * */





public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    public static AudioManager instance;


    //runs before start, loads each sound in sound manager
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(gameObject);
            return;
        }


        DontDestroyOnLoad(gameObject);
         foreach (Sound s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;
                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
                s.source.loop = s.loop;
            }   
    }
    /* theme music will play through audio manager on loop (we need music first)
    void Start()
    {
        Play("Theme");
    }
    */

//looks for sound with matching name and plays that sound
public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        //spelling error check
        if(s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
        s.source.Play();

    }
}
