using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rigidbodyPlayer;
    public LayerMask layerCanJump;
    public Transform rotationpoint;
    public Transform playerTransform;
    public RaycastHit hit;

    private bool jump;
    private float horizontal;
    private float vertical;
    private bool interact;
    private float jumpFromFeet = 3f;
    private float jumpHeight = 5f;


    private float movementspeed = 7.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
        CheckForGround();
        MovePlayer();
        
    }
    private void CheckForGround()
    {
        
        if(Physics.Raycast(transform.position, Vector3.down, out hit, jumpFromFeet, layerCanJump))
        {
            Jump();
        }
    }
    private void Inputs()
    {
        jump = Input.GetButton("Jump");
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        interact = Input.GetButtonDown("Interact");
    }
    private void MovePlayer()
    {
        Vector3 horizontalspeed = horizontal  * transform.right;
        Vector3 verticalspeed = vertical  * transform.forward;
        Vector3 SumSpeed = horizontalspeed + verticalspeed;
        SumSpeed = new Vector3(SumSpeed.x, 0f, SumSpeed.z);
        SumSpeed = SumSpeed.normalized * movementspeed;
        rigidbodyPlayer.AddForce(new Vector3(SumSpeed.x, 0f, SumSpeed.z));
        
        if (Input.GetKey(KeyCode.W))
        {
           transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Lerp(transform.eulerAngles.y, rotationpoint.eulerAngles.y, Time.deltaTime*2f), transform.eulerAngles.z);
        }
    }
    private void Jump()
    {
        // Try to jump with boost
        if (jump)
        {
            rigidbodyPlayer.AddForce(Vector2.up * jumpHeight * 2);
        }
    }
}
