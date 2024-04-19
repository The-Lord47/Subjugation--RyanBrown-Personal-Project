using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class playerMovement : MonoBehaviour
{
    GameController gameController;

    float horizontalInput;
    float verticalInput;

    Rigidbody player_rb;

    Animator _animator;

    //---------------PUBLIC VARIABLES---------------



    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        player_rb = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //---------------MOVES THE CHARACTER AROUND THE ENVIRONMENT---------------

        //gets horizontal (left and right) and vertical (up and down) inputs from the player
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //updates the character velocity based on the player input
        player_rb.velocity = new Vector3(horizontalInput * gameController.playerSpeed, 0f, verticalInput * gameController.playerSpeed);

        //rotates the character when moving towards the direction of movement
        if (horizontalInput != 0f && verticalInput != 0f)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(horizontalInput, 0f, verticalInput));
        }

        //---------------ANIMATION CONTROL---------------
        if(player_rb.velocity.magnitude > 0f)
        {
            _animator.SetBool("isMoving", true);
        }
        else
        {
            _animator.SetBool("isMoving", false);
        }

    }
}
