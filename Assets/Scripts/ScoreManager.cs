using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public GameObject coinGroup;
    
    public float timer;
    public bool timerEnabled = true;

    public Text scoreNumberText;
    public Text remainingNumberText;
    public Text timerNumberText;

    public int scoreFromCoin = 0;

    private int collectedCoins = 0;
    public int totalCoins;

    public int minutes, seconds;

    private void Start() 
    {
        totalCoins = coinGroup.transform.childCount;
        UpdateScore();
    }

    private void Update()
    {
        if (timerEnabled)
        {
            timer += Time.deltaTime;
            minutes = Mathf.FloorToInt(timer / 60f);
            seconds = Mathf.FloorToInt(timer - minutes * 60f);
            UpdateTimer();
        }

    }

    public void AddCoinScore(int scoreToAdd)
    {
        collectedCoins += 1;
        scoreFromCoin += scoreToAdd;
        UpdateScore();
    }            

    public void UpdateScore()
    {
        scoreNumberText.text = scoreFromCoin.ToString();
        remainingNumberText.text = (totalCoins - collectedCoins).ToString() + "/" + totalCoins.ToString();
    }

    private void UpdateTimer()
    {
        string time = string.Format("{0:0}:{1:00}", minutes, seconds);
        timerNumberText.text = time;
    }

    public float CalcFinalScore()
    {
        //100 coins, 1 coin = 100 points
        //1 sec = -5 points

        float finalScore = scoreFromCoin - (seconds * 5);

        return finalScore;
    }
}
