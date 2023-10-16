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
    [SerializeField] private int lifetime;
    public Rigidbody2D rb2d;
    public float shootSpeed;
    private UmbrellaBehaviour umbrella;
    private Transform umbrellaRotation;
    private Collider2D bulletCollider;
    public GameObject destroyEffect;
    //public GameObject ricochetEffect;
    public GameObject bashEffect;

    CowController target;
    Vector2 moveDirection;

    CowHealthBehavior player;

    /// <summary>
    /// Grabs umbrella script
    /// </summary>
    private void Start()
    {
        umbrella = FindObjectOfType<UmbrellaBehaviour>();
        rb2d.velocity = shootSpeed * transform.up;
        umbrellaRotation = umbrella.gameObject.GetComponentInParent<Transform>();
        bulletCollider = GetComponent<Collider2D>();
        lifetime = 0;

        rb2d = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<CowController>();
        player = GameObject.FindObjectOfType<CowHealthBehavior>();
        moveDirection = (target.transform.position - transform.position).normalized * shootSpeed;
        rb2d.velocity = new Vector2(moveDirection.x, moveDirection.y);
    }
    /// <summary>
    /// Handles the timer. If bullets stick around for too long, they get deleted to save memory.
    /// </summary>
    private void Update()
    {
        lifetime++;

        if (lifetime >= 777)
        {
            Debug.Log("Bullet deleted of old age");
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Destroys the bullet as well as prints debug statements
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Umbrella"))
        {
            Debug.Log("Bullet has hit a wall.");
            Instantiate(destroyEffect, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Bullet has hit the Umbrella.");

            if (umbrella.isOpen)
            {
                if (umbrella.isBashing == true)
                {
                    StartCoroutine(BulletBash());
                }
                else
                {
                    StartCoroutine(BulletRicochet());
                }
            }
        }

        if (collision.gameObject.TryGetComponent<RangedEnemyBehavior>(out RangedEnemyBehavior
            enemyComponent) && collision.CompareTag("RangedEnemy"))
        {
            enemyComponent.TakeDamage(1f);
        }

        if (collision.gameObject.TryGetComponent<MeleeEnemyBehavior>(out MeleeEnemyBehavior
            meleeEnemyComponent) && collision.CompareTag("MeleeEnemy"))
        {
            meleeEnemyComponent.TakeDamage(1f);
        }

        if (collision.CompareTag("Player"))
        {
            player.TakeDamage(1f);
        }

    }

    /// <summary>
    /// Handles what should happen if the bullet is "bashed".
    /// </summary>
    /// <returns></returns>
    public IEnumerator BulletBash()
    {
        Debug.Log("Bullet Bashed!");
        bulletCollider.enabled = false;
        Instantiate(bashEffect, gameObject.transform.position, umbrella.gameObject.transform.rotation);
        gameObject.transform.rotation = umbrella.gameObject.transform.rotation;
        rb2d.velocity = (shootSpeed * 0.5f) * umbrella.gameObject.transform.up;
        lifetime = 0;
        yield return new WaitForSeconds(.1f);
        rb2d.velocity = shootSpeed * transform.up;
        yield return new WaitForSeconds(.1f);
        bulletCollider.enabled = true;
    }

    /// <summary>
    /// Handles what should happen if the bullet simple ricochets off the umbrella.
    /// </summary>
    /// <returns></returns>
    public IEnumerator BulletRicochet()
    {
        Debug.Log("Bullet Ricocheted!");
        //Instantiate(ricochetEffect, gameObject.transform.position, Quaternion.identity);
        bulletCollider.enabled = false;
        float randomFloat = Random.Range(-88f, 88f);
        Debug.Log(randomFloat);
        Quaternion umbrellaRot = umbrella.gameObject.transform.rotation;
        Quaternion randomChange = Quaternion.Euler(0, 0, randomFloat);
        transform.rotation = umbrellaRot * randomChange;
        rb2d.velocity = shootSpeed * transform.up;
        lifetime = 0;
        yield return new WaitForSeconds(.1f);
        bulletCollider.enabled = true;
    }
}