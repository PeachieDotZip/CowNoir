/*****************************************************************************
// File Name :         UmbrellaBehaviour.cs
// Author :            Harrison Weber
// Creation Date :     September 21st, 2023
//
// Brief Description : Controls how the umbrella behaves. Also handles the interactions between the umbrella and its environment.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UmbrellaBehaviour : MonoBehaviour
{
    CowController cow;
    private Animator anim;
    public bool isPoking;
    public bool isOpen;
    public bool isBashing;

    private void Awake()
    {
        cow = GetComponentInParent<CowController>();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        if (cow.cowActions.Player.UmbrellaPoke.triggered)
        {
            UmbrellaPoke();
        }
        if (cow.cowActions.Player.UmbrellaOpen.triggered)
        {
            UmbrellaOpen();
        }

        if (isOpen)
        {
            cow.speed = 5f;
        }
        else
        {
            cow.speed = 7.2f;
        }

        //vvv Umbrella Variable Control -----
        isOpen = cow.cowActions.Player.UmbrellaOpen.IsPressed();
        //^^^ Umbrella Variable Control -----



        //vvv Animation Variables -----
        anim.SetBool("isPoking", isPoking); // unused
        anim.SetBool("isOpen", isOpen);
        anim.SetBool("isBashing", isBashing); //unused
        //^^^ Animation Variables -----
    }
    private void UmbrellaPoke()
    {
        if (isOpen == false)
        {
            anim.SetTrigger("Poke");
        }
        else
        {
            anim.SetTrigger("Bash");
        }
    }
    private void UmbrellaOpen()
    {

    }

    // The following functions are used within animation events to control certain variables and interactions.

    public void PokeVoid1()
    {
        Debug.Log("Poke!");
        isPoking = true;
    }
    public void PokeVoid2()
    {
        isPoking = false;
    }
    public void BashVoid1()
    {
        Debug.Log("Bash!");
        isPoking = true;
    }
    public void BashVoid2()
    {
        Debug.Log("Bash End");
        isPoking = false;
    }
}
