using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum RotationDirection
{
    Clockwise,
    CounterClockwise
}

public class GoldCoin : MonoBehaviour
{
    [Header("Floating Settings")]
    public float floatHeight = 1f;
    public float floatSpeed = 0.25f;

    [Header("Rotation Settings")]
    public RotationDirection rotationDirection;
    public float rotationSpeed = 25f;

    [Header("Score Settings")]
    public int scoreToAdd = 100;
    
    private Vector3 startPos;
    private bool floatUp;


    private void Start()
    {
        startPos = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            other.GetComponent<ScoreManager>().AddCoinScore(scoreToAdd);
            other.GetComponent<AudioSource>().Play(0);
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        //Rotation
        if (rotationDirection == RotationDirection.Clockwise)
        {
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }
        else if (rotationDirection == RotationDirection.CounterClockwise)
        {
            transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
        }
        
        //Floating
        if (floatUp)
        {
            transform.Translate(Vector3.up * (floatSpeed * Time.deltaTime));
        }
        else
        {
            transform.Translate(Vector3.down * (floatSpeed * Time.deltaTime));
        }
        
        if (transform.position.y <= startPos.y)
        {
            floatUp = true;
        }
        else if (transform.position.y >= startPos.y + floatHeight)
        {
            floatUp = false;
        }
    }
}