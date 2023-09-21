/*****************************************************************************
// File Name :         DebugBulletBehavior.cs
// Author :            Lorien Nergard
// Creation Date :     September 21st, 2023
//
// Brief Description : Adds velocity to the bullet and destroys it accoordingly
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugBulletBehavior : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float shootSpeed;

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    private void Update()
    {
        rb2d.velocity = new Vector2(shootSpeed * 0.2f, rb2d.velocity.y);
    }

    /// <summary>
    /// Destroys the bullet as well as prints debug statements
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Umbrella")
        {
            Debug.Log("Bullet has hit a wall.");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Bullet has hit the Umbrella.");
        }

    }
}
