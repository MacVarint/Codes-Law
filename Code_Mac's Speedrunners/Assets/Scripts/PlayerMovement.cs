
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    //Other
    public LayerMask layerCanJump;
    public Transform rotationpoint;
    public Transform cameratrans;
    public CheckForGround checkForGround;

    //Player
    public Rigidbody rigidbodyPlayer;
    public Transform playerTransform;
    public Animator playerAnimator;

    //temp
    public int attackDamage = 4;

    //Movement
    private float horizontal;
    private float vertical;
    private float movementspeed = 5f;
    private bool jump;
    private float jumpHeight = 3f;
    private float jumpFromFeet = 3f;
    private float turnspeed = 4f;
    private float neweulerY = 0;

    // Update is called once per frame
    void Update()
    {
        Inputs();
        CheckForGround();
        MovePlayer();
    }
    private void CheckForGround() //Checks for ground using raycast
    {
        
        if(checkForGround.isOnGround && Input.GetButton("Jump"))
        {
            Jump();
        }
    }
    private void Inputs() //These are all the inputs
    {
        jump = Input.GetButton("Jump");
        horizontal = Mathf.Abs(Input.GetAxis("Horizontal"));
        vertical = Mathf.Abs(Input.GetAxis("Vertical"));
    }
    private void MovePlayer() //Moves player
    {

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            Vector3 horizontalspeed = horizontal * transform.forward;
            Vector3 verticalspeed = vertical * transform.forward;
            Vector3 moveDirection = horizontalspeed + verticalspeed;
            moveDirection = moveDirection.normalized;
            Vector3 realspeed = moveDirection * movementspeed;

            //Vector3 horizontalspeed = horizontal * movementspeed * Vector3.right;
            rigidbodyPlayer.velocity = new Vector3(realspeed.x, rigidbodyPlayer.velocity.y, realspeed.z);
            NewEulerY();
            rotationpoint.eulerAngles = new Vector3(cameratrans.eulerAngles.x, cameratrans.eulerAngles.y + neweulerY, cameratrans.eulerAngles.z);
            //WIP
            playerAnimator.SetBool("isRunning", true);
            float dif = Mathf.Abs(transform.eulerAngles.y - rotationpoint.eulerAngles.y); //Checks the Y rotation of the player
                if (dif < 180) //Checks if Code needs to look to the left
                {
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Lerp(transform.eulerAngles.y, rotationpoint.eulerAngles.y, Time.deltaTime * turnspeed), transform.eulerAngles.z);
                }
                else //Checks if Code needs to look to the right
                {
                    float eulerAngY = 0;
                    if (transform.eulerAngles.y > rotationpoint.eulerAngles.y)
                    {
                        eulerAngY = 360 + rotationpoint.eulerAngles.y;
                    }
                    else if(transform.eulerAngles.y < rotationpoint.eulerAngles.y)
                    {
                        eulerAngY = rotationpoint.eulerAngles.y -360;
                    }
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Lerp(transform.eulerAngles.y, eulerAngY, Time.deltaTime * turnspeed), transform.eulerAngles.z);
                }
            if(moveDirection.magnitude == 0)
            {
                playerAnimator.SetBool("isRunning", false);
            }
        }
    }
    private void Jump() //Checks if you press space
    {
        
        
        rigidbodyPlayer.AddForce(Vector2.up * jumpHeight * 60);
        checkForGround.isOnGround = false;

    }
    private void NewEulerY()
    {
        //if (Input.GetKey(KeyCode.W))
        //{
        neweulerY = 0;
        //}

        if (Input.GetKey(KeyCode.D))
        {
            neweulerY += 90;
        }
        if (Input.GetKey(KeyCode.A))
        {
            neweulerY -= 90;
        }
        if (Input.GetKey(KeyCode.S))
        {
            neweulerY += 180;
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            neweulerY = -45;
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {
            neweulerY = -135;
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            neweulerY = 135;
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
        {
            neweulerY = 45;
        }
    }
}