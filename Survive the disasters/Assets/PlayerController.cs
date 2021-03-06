﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private PlayerMotor p_motor;
    private Player player;

    Vector2 inputMovement;

    float inputMouseX = 0;
    float inputMouseY = 0;
    private float sensitivity = 1;

    private void Start()
    {
        p_motor = GetComponent<PlayerMotor>();
        player = GetComponent<Player>();
    }
    // Update is called once per frame
    private void Update()
    {
        inputMovement.x = Input.GetAxisRaw("Horizontal");
        inputMovement.y = Input.GetAxisRaw("Vertical");

        inputMouseX += Input.GetAxis("Mouse X") * sensitivity;
        inputMouseY += Input.GetAxis("Mouse Y") * sensitivity;

        inputMouseY = Mathf.Clamp(inputMouseY, -80, 80);

        //Check keyboard inputs

        if(Input.GetButtonDown("Cancel"))
        {
            
        }

        if(Input.GetButton("Sprint"))
        {
            if(player.isGrounded())
            {
                player.movement.isRunning = true;
            }
        }else
        {
            player.movement.isRunning = false;
        }

        if(Input.GetButtonDown("Jump"))
        {
            if(player.isGrounded())
            {
                p_motor.Jump();
            }
        }

        if(Input.GetButtonDown("Fire1"))
        {
     
        }
        if (Input.GetButtonUp("Fire1"))
        {
      
        }

    }


    private void FixedUpdate()
    {
        p_motor.DoMovement(p_motor.CalculateMovement(inputMovement.normalized));
        p_motor.DoRotation(inputMouseX, inputMouseY);
    }




}
