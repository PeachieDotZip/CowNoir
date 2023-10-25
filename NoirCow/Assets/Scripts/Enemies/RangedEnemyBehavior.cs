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
<<<<<<< Updated upstream
=======
<<<<<<< HEAD

    private Animator anim;
=======
>>>>>>> 6c1f16f42df958120d324e2bed590807675137c6
>>>>>>> Stashed changes

    /// <summary>
    /// Grabs the player and sets health
    /// </summary>
    void Start()
    {
        isShooting = false;
        player = FindObjectOfType<CowController>();
        anim = GetComponent<Animator>();
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

<<<<<<< Updated upstream
        if (enemyHealth == 0)
        {
=======
<<<<<<< HEAD
        if (enemyHealth <= 0)
        {
            //instantiate death vfx
=======
        if (enemyHealth == 0)
        {
>>>>>>> 6c1f16f42df958120d324e2bed590807675137c6
>>>>>>> Stashed changes
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
        anim.SetTrigger("shoot");
        yield return new WaitForSeconds(shootTimer);
        anim.ResetTrigger("shoot");
        isShooting = false;
    }

    public void TakeDamage(float damageAmount)
    {
        enemyHealth -= damageAmount;
<<<<<<< Updated upstream
    }
    
=======
<<<<<<< HEAD
        //playhurtanim
    }
=======
    }
    
>>>>>>> 6c1f16f42df958120d324e2bed590807675137c6
>>>>>>> Stashed changes

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet_Ricochet"))
        {
            TakeDamage(1);
        }
        if (collision.gameObject.CompareTag("Bullet_Bash"))
        {
            TakeDamage(3);
        }
    }
    
    public void Fire()
    {
        Instantiate(bulletPrefab, shootPos.position, transform.rotation);
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