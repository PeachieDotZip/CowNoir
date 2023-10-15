/*****************************************************************************
// File Name :         CanvasScript.cs
// Author :            Harrison Weber
// Creation Date :     October 10th, 2023
//
// Brief Description : Contains the animation events to be used in sequences such as the player entering a door.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    private GameManager gameManager;
    private Animator UIanim;
    public GameObject newRoom;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        UIanim = GetComponent<Animator>();
    }

    /// <summary>
    /// Teleports player to next room.
    /// </summary>
    public void TeleportPlayer()
    {
        gameManager.playerPos.position = newRoom.transform.position;
    }
    /// <summary>
    /// Activates the enemies in the new room.
    /// </summary>
    public void SpawnEnemies()
    {

    }
    /// <summary>
    /// Returns the animator to idle, allowing the player to enter another door.
    /// </summary>
    public void EndDoorSequence()
    {
        UIanim.SetTrigger("ReturnToIdle");
    }
}
