using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class OldPauseMenu : MonoBehaviour
{
    [Header("References")]
    public Text titleText;
    
    public Button resumeButton;
    public Button quitButton;

    public Slider mouseSensitivitySlider;
    public Text mouseSensitivitySliderText;
    public Image soundOnIcon, soundOffIcon;

    [Header("External References")]
    public GameManager gameManager;
    public FP fP;
    public AudioSource backgroundMusicAudioSource;

    [Header("Title")]
    [SerializeField] private string newTitleText = "INTERACT";
    
    [Header("Mouse Sensitivity")]
    public int defaultMouseSensitivity = 50;
    private int mouseSensitivity;

    [Header("Background Music")]
    private bool muted = false;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;

        titleText = titleText.GetComponent<Text>();
        titleText.text = newTitleText;
        
        resumeButton = resumeButton.GetComponent<Button>();
        quitButton = quitButton.GetComponent<Button>();

        mouseSensitivitySlider = mouseSensitivitySlider.GetComponent<Slider>();
        mouseSensitivitySliderText = mouseSensitivitySliderText.GetComponent<Text>();

        fP = fP.GetComponent<FP>();

        if (!PlayerPrefs.HasKey("MouseSensitivity"))
        {
            PlayerPrefs.SetInt("MouseSensitivity", defaultMouseSensitivity);
        }
        else
        {
            mouseSensitivity = PlayerPrefs.GetInt("MouseSensitivity");
            mouseSensitivitySlider.value = mouseSensitivity / defaultMouseSensitivity;
        }
    }

}



