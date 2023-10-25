/*****************************************************************************
// File Name :         CrateBehaviour.cs
// Author :            Harrison Weber
// Creation Date :     October 16th, 2023
//
// Brief Description : Controls the interactions between the crates and the rest of the game world.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateBehaviour : MonoBehaviour
{
    private UmbrellaBehaviour umbrella;
    private Collider crateCol;
    public GameObject breakEffect;

    // Start is called before the first frame update
    void Start()
    {
        umbrella = FindObjectOfType<UmbrellaBehaviour>();
        crateCol = GetComponent<Collider>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Umbrella"))
        {
            Debug.Log("crate touched umbrella");
            if (umbrella.isBashing == true)
            {
                BreakSelf();
            }
        }
        if (collision.gameObject.CompareTag("Enemy_Charging") || collision.gameObject.CompareTag("Enemy"))
        {
            BreakSelf();
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Umbrella"))
        {
            Debug.Log("crate touched umbrella");
            if (umbrella.isBashing == true)
            {
                BreakSelf();
            }
        }
    }

    public void BreakSelf()
    {
        Instantiate(breakEffect, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
