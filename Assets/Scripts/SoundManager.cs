using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.UIElements;

using Image = UnityEngine.UI.Image;
using Cursor = UnityEngine.Cursor;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Image soundOnIcon;
    [SerializeField] Image soundOffIcon;

    public AudioSource audioSource;

    private bool muted = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = audioSource.GetComponent<AudioSource>();

        if(!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }

        else
        {
            Load();
        }

        UpdateButtonIcon();
        audioSource.mute = muted;
    }

    public void OnButtonPress()
    {
        print("Button pressed");
        if(muted == false)
        {
            muted = true;
            audioSource.mute = true;
        }
        else
        {
            muted = false;
            audioSource.mute = false;
        }

        Save();
        UpdateButtonIcon();
    }

    private void UpdateButtonIcon()
    {
        if(muted == false)
        {
            soundOnIcon.enabled = true;
            soundOffIcon.enabled = false;
        }

        else
        {
            soundOnIcon.enabled = false;
            soundOffIcon.enabled = true;
        }
    }
    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }
}   
