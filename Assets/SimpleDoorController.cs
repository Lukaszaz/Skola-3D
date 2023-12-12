using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDoorController : MonoBehaviour
{
    public float interactionDistance = 3f; // Adjust the distance as needed
    public GUIStyle guiStyle;
    public Texture2D clickIcon;

    private bool isOpen = false;
    private Quaternion initialRotation;

    void Start()
    {
        initialRotation = transform.rotation;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TryToggleDoor();
        }
    }

    void TryToggleDoor()
    {
        // Check if the player is close enough to interact with the door
        if (IsPlayerNearby())
        {
            ToggleDoor();
        }
    }

    void ToggleDoor()
    {
        isOpen = !isOpen;

        float targetAngle = isOpen ? 90f : 0f; // Adjust the angle as needed

        // Smoothly rotate the door
        StartCoroutine(RotateDoor(targetAngle, 0.5f));
    }

    bool IsPlayerNearby()
    {
        // Check the distance between the player and the door
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        return distance <= interactionDistance;
    }

    System.Collections.IEnumerator RotateDoor(float targetAngle, float duration)
    {
        Quaternion startRotation = transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(initialRotation.eulerAngles.x, targetAngle, initialRotation.eulerAngles.z);

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = targetRotation;
    }

    void OnGUI()
    {
        if (IsPlayerNearby())
        {
            // Display left-click instructions
            float iconSize = 64f;
            float iconOffset = iconSize / 2f;
            GUI.Label(new Rect(Screen.width / 2 - iconOffset, Screen.height / 2 - iconOffset, iconSize, iconSize), clickIcon);

            // Display text
            GUI.Label(new Rect(Screen.width / 2 + iconOffset, Screen.height / 2 - iconOffset, 200f, 30f), "Left-Click to Open/Close", guiStyle);
        }
    }
}