using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FP : MonoBehaviour
{
    public bool canMove = true;

    private int sensitivity;

    public Transform orientation;

    float xRotation;
    float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (!PlayerPrefs.HasKey("MouseSensitivity"))
        {
            sensitivity = 50;
        }
        else
        {
            sensitivity = PlayerPrefs.GetInt("MouseSensitivity");
        }
    }

    private void Update()
    {
        if (canMove)
        {
            // get mouse input
            float mouseX = Input.GetAxisRaw("Mouse X") * sensitivity * Time.deltaTime;
            float mouseY = Input.GetAxisRaw("Mouse Y") * sensitivity * Time.deltaTime;

            yRotation += mouseX;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            // rotate cam and orientation
            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        }
    }

    public void UpdateSense(int i)
    {
        sensitivity = i;
    }
}
