using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController characterController;
    float xDirection;
    float zDirection;
    public float speed = 15f;

    public float gravity = -9.81f;
    public Vector3 velocity;
    public Transform groundCheck;
    public bool isGrounded;
    public float groundDistance = 0.4f;
    public LayerMask groundLayerMask;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayerMask);

        if (velocity.y < 0 && isGrounded)
        {
            velocity.y = -2f;
        }

        xDirection = Input.GetAxis("Horizontal");
        zDirection = Input.GetAxis("Vertical");

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(MovePlayer() * speed * Time.deltaTime);

        characterController.Move(velocity * Time.deltaTime);

    }

    public Vector3 MovePlayer()
    {
        return transform.right * xDirection + transform.forward * zDirection;

    }


}
