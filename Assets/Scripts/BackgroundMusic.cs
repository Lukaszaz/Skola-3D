using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic backgroundMusic;
    void Awake()
    {
        if(backgroundMusic == null)
        {
            backgroundMusic = this;
            DontDestroyOnLoad(backgroundMusic);
        }
    }
    
    void Start()
    {
        if (PlayerPrefs.GetInt("Muted") == 1)
        {
            gameObject.GetComponent<AudioSource>().mute = true;
        }
        else if (PlayerPrefs.GetInt("Muted") == 0)
        {
            gameObject.GetComponent<AudioSource>().mute = false;
        }
    }

    public void MuteBackgroundMusic(bool b)
    {
        if (b)
            gameObject.GetComponent<AudioSource>().mute = true;
        else
            gameObject.GetComponent<AudioSource>().mute = false;
    }
    
}
