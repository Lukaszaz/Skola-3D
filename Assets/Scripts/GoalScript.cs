using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalScript : MonoBehaviour
{   
    public GameObject hud;
    public Text winText;

    public ScoreManager scoreManager;
    public PlayerMovement playerMovement;
    public FP fP;

    private void Start()
    {
        scoreManager = scoreManager.GetComponent<ScoreManager>();
        winText = winText.GetComponent<Text>();
        playerMovement = playerMovement.GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "Player")
        {
            playerMovement.canMove = false;
            fP.canMove = false;
            Cursor.visible = true;

            scoreManager.timerEnabled = false;

            for (int i = 0; i < hud.transform.childCount; i++)
            {
                hud.transform.GetChild(i).gameObject.SetActive(false);
            }

            hud.transform.GetChild(1).gameObject.SetActive(true); //Make sure VictoryText is the first child in HUD
            hud.transform.GetChild(0).gameObject.SetActive(true); //Make sure Black is the second child in HUD
            winText.enabled = true;
            winText.text = "Congratulations you escaped!\nCoins collected: " + scoreManager.scoreFromCoin/100
                + "\nCoins missed: " + (scoreManager.totalCoins - (scoreManager.scoreFromCoin / 100))
                + "\nTime: " + string.Format("{0:0}:{1:00}", scoreManager.minutes, scoreManager.seconds)
                + "\nFinal Score: " + scoreManager.CalcFinalScore().ToString()
                + "\n\nPress \"R\" to try again, or \"Esc\" to exit!";
        }

    }
}
