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
    public bool isShooting;

    public float enemyHealth = 3;

    /// <summary>
    /// Grabs the player and sets health
    /// </summary>
    void Start()
    {
        isShooting = false;
        player = FindObjectOfType<CowController>();
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

        if (enemyHealth == 0)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Coroutine to instantiate the bullets
    /// </summary>
    /// <returns></returns>
    IEnumerator Shoot()
    {
        isShooting = true;

        Instantiate(bulletPrefab, shootPos.position, transform.rotation);
        yield return new WaitForSeconds(shootTimer);

        isShooting = false;
    }

    public void TakeDamage(float damageAmount)
    {
        enemyHealth -= damageAmount;
    }
    

    /// <summary>
    /// Draws the range so it can be easily tested in the scene view.
    /// </summary>
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}