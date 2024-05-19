using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 300f;
    public float jumpSpeed = 8f;
    public float gravity = -20f;
    private float ySpeed;
    public CharacterController runner;
    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        runner = GetComponent<CharacterController>();

    }
    // Update is called once per frame
    void Update()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalMove, 0, verticalMove);
        moveDirection.Normalize();
        float magnitude = moveDirection.magnitude;
        magnitude = Mathf.Clamp01(magnitude);

        Vector3 move = moveDirection * magnitude * speed;

        if (runner.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                ySpeed = jumpSpeed;
            }
            else
            {
                ySpeed = -0.5f;
            }
        }
        else
        {
            ySpeed += Physics.gravity.y * Time.deltaTime;
        }

        move.y = ySpeed;

        runner.Move(move * Time.deltaTime);

        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotate = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, rotationSpeed * Time.deltaTime);
        }
    }
}