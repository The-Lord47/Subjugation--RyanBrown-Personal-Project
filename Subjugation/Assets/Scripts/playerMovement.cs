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

    //---------------PUBLIC VARIABLES---------------



    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        player_rb = GetComponent<Rigidbody>();
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

    }
}
