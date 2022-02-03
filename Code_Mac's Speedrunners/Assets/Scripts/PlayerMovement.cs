using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    //Other
    public LayerMask layerCanJump;
    public Transform rotationpoint;
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
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }
    private void MovePlayer() //Moves player
    {
        //WIP
/*        if (horizontal > 0 || vertical > 0)
        {
            playerAnimator.SetBool("State", true);
        }
        else
        {
            playerAnimator.SetBool("State", false);
        }*/
        Vector3 horizontalspeed = horizontal * transform.right;
        Vector3 verticalspeed = vertical * transform.forward;
        Vector3 moveDirection = horizontalspeed + verticalspeed;
        moveDirection = moveDirection.normalized;
        Vector3 realspeed = moveDirection * movementspeed;
        //Vector3 horizontalspeed = horizontal * movementspeed * Vector3.right;
        rigidbodyPlayer.velocity = new Vector3(realspeed.x, rigidbodyPlayer.velocity.y, realspeed.z);


        if (Input.GetKey(KeyCode.W)) //Checks if you are pressing W
        {
            //WIP
            playerAnimator.SetBool("isRunning", true);
            float dif = Mathf.Abs(transform.eulerAngles.y - rotationpoint.eulerAngles.y); //Checks the Y rotation of the player
            if (dif < 180) //Checks if Code needs to look to the left
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Lerp(transform.eulerAngles.y, rotationpoint.eulerAngles.y, Time.deltaTime * turnspeed), transform.eulerAngles.z);
            }
            else //Checks if the Code needs to look to the right
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
        }
        else
        {
            //WIP
            playerAnimator.SetBool("isRunning", false);
        }
    }
    private void Jump() //Checks if you press space
    {
        
        
        rigidbodyPlayer.AddForce(Vector2.up * jumpHeight * 60);
        checkForGround.isOnGround = false;

        }
}