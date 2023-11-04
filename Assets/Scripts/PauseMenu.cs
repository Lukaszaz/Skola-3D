using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
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
    public BackgroundMusic backgroundMusic;
    public AudioSource backgroundMusicAudioSource;

    [Header("Title")]
    [SerializeField] private string newTitleText = "MAZE";
    
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

        backgroundMusic = backgroundMusic.GetComponent<BackgroundMusic>();
        backgroundMusicAudioSource = backgroundMusic.GetComponent<AudioSource>();


        if (!PlayerPrefs.HasKey("MouseSensitivity"))
        {
            PlayerPrefs.SetInt("MouseSensitivity", defaultMouseSensitivity);
        }
        else
        {
            mouseSensitivity = PlayerPrefs.GetInt("MouseSensitivity");
            mouseSensitivitySlider.value = mouseSensitivity / defaultMouseSensitivity;
        }

        if (!PlayerPrefs.HasKey("Muted"))
        {
            PlayerPrefs.SetInt("Muted", 0);
            LoadMute();
        }
        else
        {
            LoadMute();
        }

        UpdateMuteButtonIcon();
        ToggleMute(muted);
    }

    public void OnResumeButtonPress()
    {
        gameManager.TogglePause();
    }

    public void OnMouseSensitivitySliderChange()
    {
        mouseSensitivity = defaultMouseSensitivity * Mathf.RoundToInt(mouseSensitivitySlider.value);
        mouseSensitivitySliderText.text = $"x{mouseSensitivitySlider.value.ToString(CultureInfo.InvariantCulture)} ({mouseSensitivity.ToString(CultureInfo.InvariantCulture)})";
    }

    public void OnMouseSensitivitySliderUp()
    {
        PlayerPrefs.SetInt("MouseSensitivity", mouseSensitivity);
        fP.UpdateSense(mouseSensitivity);
    }
    
    public void OnQuitButtonPress()
    {
        Application.Quit();
    }

    public void OnMuteButtonPress()
    {
        if (!muted)
        {
            muted = true;
            ToggleMute(true);
        }
        else
        {
            muted = false;
            ToggleMute(false);
        }

        SaveMute();
        UpdateMuteButtonIcon();
    }

    private void UpdateMuteButtonIcon()
    {
        if (!muted)
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

    private void ToggleMute(bool b)
    {
        backgroundMusic.MuteBackgroundMusic(muted);
    }

    private void LoadMute()
    {
        muted = PlayerPrefs.GetInt("Muted") == 1;
    }

    private void SaveMute()
    {
        PlayerPrefs.SetInt("Muted", muted ? 1 : 0);
    }
}
