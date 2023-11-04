using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    [Header("References")]
    public ScoreManager scoreManager;

    [Header("Damage")]
    public int damage = 10;
    
    private Animation anim;
    private new AudioSource audio;
    private void Start()
    {
        scoreManager = scoreManager.GetComponent<ScoreManager>();

        anim = GetComponent<Animation>();
        audio = GetComponent<AudioSource>();
    }
    
    public void TriggerAttack()
    {
        if (anim.isPlaying) return;
        anim.Play();
        audio.Play(); //Sound effects obtained from https://www.zapsplat.com
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name != "Player" || anim.isPlaying) return;

        scoreManager.scoreFromCoin -= damage;
        scoreManager.UpdateScore();

    }
}
