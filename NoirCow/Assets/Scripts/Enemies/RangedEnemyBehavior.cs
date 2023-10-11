/*****************************************************************************
// File Name :         RangedEnemyBehavior.cs
// Author :            Lorien Nergard
// Creation Date :     October 11th, 2023
//
// Brief Description : Controls the ranged enemy
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyBehavior : MonoBehaviour
{
    private float disToPlayer;
    public float range;
    CowController player;

    public Transform shootPos;
    public GameObject bulletPrefab;
    public float shootTimer;
    private bool isShooting;

    //public float enemyHealth = 3;

    /// <summary>
    /// Grabs the player and sets health
    /// </summary>
    void Start()
    {
        isShooting = false;
        //enemyHealth = 3;
        player = GameObject.FindObjectOfType<CowController>();
    }

    /// <summary>
    /// Starts & stops the coroutine
    /// </summary>
    void Update()
    {
        disToPlayer = Vector2.Distance(transform.position, player.transform.position);
        if (disToPlayer <= range & isShooting == false)
        {
            StartCoroutine(Shoot());
        }
        else
        {
            StopCoroutine(Shoot());
        }
    }

    /// <summary>
    /// Coroutine to instantiate the bullets
    /// </summary>
    /// <returns></returns>
    IEnumerator Shoot()
    {
        isShooting = true;

        Instantiate(bulletPrefab, shootPos.position, Quaternion.identity);
        yield return new WaitForSeconds(shootTimer);

        isShooting = false;
    }

    /* Health function
    public void TakeDamage(float damageAmount)
    {
        enemyHealth -= damageAmount;
        Debug.Log("Ranged enemy lost " + damageAmount + " health. Enemy has " +
            enemyHealth + " health remaining.");
    }
    */
}