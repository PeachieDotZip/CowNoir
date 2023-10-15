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
using UnityEngine.SceneManagement;

public class CowController : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;
    private Vector2 movementInput;
    public CowInput cowActions;
    private Animator umbrellaAnim;
    public GameObject[] gunners;

    /// <summary>
    /// Assigns cowActions to measure input.
    /// Assigns rigidbody and animator of umbrella.
    /// </summary>
    private void Awake()
    {
        cowActions = new CowInput();

        rb = GetComponent<Rigidbody2D>();
        umbrellaAnim = GetComponentInChildren<Animator>();
    }

    /// <summary>
    /// Controls how fast the player moves.
    /// </summary>
    private void FixedUpdate()
    {
        rb.velocity = movementInput * speed;
    }

    /// <summary>
    /// Debug prototype code, remove whenever
    /// </summary>
    private void Update()
    {
        if (cowActions.Player.press1.triggered)
        {
            gunners[0].SetActive(true);
            gunners[1].SetActive(false);
            gunners[2].SetActive(false);
            gunners[3].SetActive(false);
            gunners[4].SetActive(false);
            gunners[5].SetActive(false);
            gunners[6].SetActive(true);
        }
        if (cowActions.Player.press2.triggered)
        {
            gunners[0].SetActive(false);
            gunners[1].SetActive(true);
            gunners[2].SetActive(true);
            gunners[3].SetActive(true);
            gunners[4].SetActive(true);
            gunners[5].SetActive(true);
            gunners[6].SetActive(false);
        }
        if (cowActions.Player.press3.triggered)
        {
            SceneManager.LoadScene(0);
        }
    }

    /// <summary>
    /// Measures input and move player
    /// </summary>
    /// <param name="inputValue"></param>
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