using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody playerRb;
    public float playerSpeed = 10f;
    Vector3 movement;
    private bool isPlayerMoving = false;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Check if player is moving
        if(Input.GetButton("Horizontal") || Input.GetButton("Vertical")){
            isPlayerMoving = true;
        }
        else {
            isPlayerMoving = false;
        }

         //get input for horizontal and vertical movement
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        //Move player according to direction player is facing
         movement = Camera.main.transform.right * horizontalInput + Camera.main.transform.forward * verticalInput;
    }

    //Using fixedUpdate over update, its more suited to physics and makes movement smooth
    private void FixedUpdate()
    {
        //Stop player when key released (Prevents sliding)
        if (isPlayerMoving)
        {
            //Normalized stops increased speed when moving in direcrions -> NE,SW etc
            playerRb.AddForce(movement.normalized * playerSpeed * 3f, ForceMode.Acceleration);
        }
        else
        {
            playerRb.velocity = Vector3.zero;
        }
        //Stop Player from floating up when looking up and moving
        if (playerRb.position.y > 1.05f)
        {
            transform.position = new Vector3(transform.position.x, 1.05f, transform.position.z);
        }
    }

}