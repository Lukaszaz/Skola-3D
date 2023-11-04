using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public ScoreManager scoreManager;

    public int damage = 10;

    private GameObject spikes;
    private Animation anim;
    private new AudioSource audio;
    private void Start()
    {
        scoreManager = scoreManager.GetComponent<ScoreManager>();

        spikes = transform.GetChild(0).GetChild(0).gameObject;
        anim = spikes.GetComponent<Animation>();
        audio = spikes.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name != "Player" || spikes.GetComponent<Animation>().isPlaying) return;

        scoreManager.scoreFromCoin -= damage;
        scoreManager.UpdateScore();

        TriggerAttack();
    }

    public void TriggerAttack()
    {
        anim.Play();
        audio.Play(); //Sound effects obtained from https://www.zapsplat.com
    }
}
