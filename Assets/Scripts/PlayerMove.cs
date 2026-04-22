using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float playerSpeed = 10f;
    public float momentumDamping = 5f;
    public float myGravity = -10f;
    public float jumpForce = 5f;
    private CharacterController myCC;
    public Animator camAnim;
    private bool isWalking;
    private Vector3 inputVector;
    private Vector3 movementVector;
    private float yVelocity;
    private bool isGrounded;

    void Start()
    {
        myCC = GetComponent<CharacterController>();
    }
    void Update()
    {
        CheckGround();
        GetInput();
        ApplyGravity();
        Jump();
        MovePlayer();
        //ChechForHeadBob();

        camAnim.SetBool("isWalking", isWalking);
    }
    void CheckGround()
    {
        isGrounded = myCC.isGrounded;

        if (isGrounded && yVelocity < 0)
        {
            yVelocity = -2f;
        }
    }
    void GetInput()
    {
        if (Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.D))
        {
            inputVector = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            inputVector.Normalize();
            inputVector = transform.TransformDirection(inputVector);

            isWalking = true;
        }
        else
        {
            inputVector = Vector3.Lerp(inputVector, Vector3.zero, momentumDamping * Time.deltaTime);

            isWalking = false;
        }
        movementVector = (inputVector * playerSpeed) + (Vector3.up * myGravity);
    }
    void ApplyGravity()
    {
        yVelocity += myGravity * Time.deltaTime;
    }

    void Jump()
    {
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            yVelocity = jumpForce;
        }
    }
    void MovePlayer()
    {
        movementVector = inputVector * playerSpeed;
        movementVector.y = yVelocity;

        myCC.Move(movementVector * Time.deltaTime);
    }

    //void ChechForHeadBob()
    //{
    //    if (myCC.velocity.magnitude > 0.1f)
    //    {
    //        isWalking = true;
    //    }
    //    else
    //    {
    //        isWalking = false;
    //    }
    //}
}