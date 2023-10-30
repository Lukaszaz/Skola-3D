using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public Transform cameraTransform;
    public float movementSpeed = 5f;

    Rigidbody body;
    float horizontal;
    float vertical;


    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0;
        right.y = 0;

        Vector3 direction = forward * vertical + right * horizontal;

        Vector3 movement = transform.position + direction.normalized * Time.fixedDeltaTime * movementSpeed;

        body.MovePosition(movement);

        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}
