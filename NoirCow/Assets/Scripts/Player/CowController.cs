/*****************************************************************************
// File Name :         CowController.cs
// Author :            Harrison Weber
// Creation Date :     September 21st, 2023
//
// Brief Description : Controls all variables and interactions the player can have.
*****************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CowController : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;
    private Vector2 movementInput;
    public CowInput cowActions;
    private Animator umbrellaAnim;

    private void Awake()
    {
        cowActions = new CowInput();

        rb = GetComponent<Rigidbody2D>();
        umbrellaAnim = GetComponentInChildren<Animator>();
    }
    private void Start()
    {
        
    }


    private void FixedUpdate()
    {
        rb.velocity = movementInput * speed;
    }

    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
    }
    private void OnEnable()
    {
        cowActions.Enable();
    }
    private void OnDisable()
    {
        cowActions.Disable();
    }
}