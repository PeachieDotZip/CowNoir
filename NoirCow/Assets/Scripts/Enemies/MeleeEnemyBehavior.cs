using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyBehavior : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    Rigidbody2D rb2d;
    Vector2 moveDirection;

    public float chargeDelayTime;
    private float disToPlayer;
    public float range;

    public bool canCharge;
    public bool isCharging;
    public bool isRetreating;

    public float currentSpeed;

    public Transform player;
    public Transform target;

    public float enemyHealth = 3;

<<<<<<< Updated upstream
=======
<<<<<<< HEAD
    private UmbrellaBehaviour umbrella;


    private Animator anim;
    public GameObject bashedEffect;
    public GameObject deathEffect;

=======
>>>>>>> 6c1f16f42df958120d324e2bed590807675137c6
>>>>>>> Stashed changes

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        canCharge = true;
        isCharging = false;
        umbrella = FindObjectOfType<UmbrellaBehaviour>();

        anim = GetComponent<Animator>();
    }

    void Update()
    {
        disToPlayer = Vector2.Distance(transform.position, player.position);


        if (target == null)
        {
            target = player;
        }

        if (!isCharging && canCharge)
        {

            if (disToPlayer <= range)
            {
                anim.SetTrigger("begin charge");
            }
        }

<<<<<<< Updated upstream
=======
<<<<<<< HEAD
        if (enemyHealth <= 0)
=======
>>>>>>> Stashed changes
        if (enemyHealth == 0)
        {
            Destroy(gameObject);
        }

        if (isDazed)
>>>>>>> 6c1f16f42df958120d324e2bed590807675137c6
        {
            //instantiate death vfx
            Destroy(gameObject);
        }
        if (isCharging)
        {
            MoveEnemy();
        }
        else
        {
            rb2d.velocity = new Vector2(0, 0);
        }
        if (isRetreating)
        {
            //MoveEnemy_Retreat();
        }
    }

    public void TakeDamage(float damageAmount)
    {
        enemyHealth -= damageAmount;
    }

    private void MoveEnemy()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }
    private void MoveEnemyRetreat()
    {
        //transform.position = Vector3.MoveTowards(this.transform.position, target.position, moveSpeed * Time.deltaTime);
    }

    private IEnumerator HitWall(float time)
    {
        gameObject.tag = "Enemy";
        anim.SetBool("isDazed", true);
        isCharging = false;
        canCharge = false;
        rb2d.velocity = new Vector2 (0, 0);
        yield return new WaitForSeconds(time);
        rb2d.velocity = new Vector2(0, 0);
        anim.SetBool("isDazed", false);
        canCharge = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("melee enemy hit a wall");
            StartCoroutine(HitWall(5f));
            //more cooldown
        }
        if (collision.gameObject.CompareTag("Crate"))
        {
            Debug.Log("melee enemy hit the player or a crate");
            StartCoroutine(HitWall(3f));
            //less cooldown
        }
        if (collision.collider.CompareTag("Player") & umbrella.isBashing == false & !collision.collider.CompareTag(("Umbrella")))
        {
            Debug.Log("melee enemy hit the player or a crate");
            StartCoroutine(HitWall(3f));
            //less cooldown
        }

        if (collision.collider.CompareTag("Umbrella"))
        {
            Debug.Log("melee enemy hit umbrella");

            if (isCharging == true && umbrella.isBashing == true)
            {
                StartCoroutine(HitWall(5.5f));
                Instantiate(bashedEffect, gameObject.transform.position, umbrella.gameObject.transform.rotation);
                //stunned by player
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("Umbrella"))
        {
            Debug.Log("melee enemy hit umbrella");

            if (isCharging == true && umbrella.isBashing == true)
            {
                StartCoroutine(HitWall(5.5f));
                Instantiate(bashedEffect, gameObject.transform.position, umbrella.gameObject.transform.rotation);
                //stunned by player
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Umbrella"))
        {
            if (isCharging == false && umbrella.isPoking == true)
            {
                TakeDamage(1);
                Instantiate(deathEffect, gameObject.transform.position, umbrella.gameObject.transform.rotation);
            }
        }
    }

    /// <summary>
    /// Draws the range so it can be easily tested in the scene view.
    /// </summary>
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

<<<<<<< Updated upstream
    public void TakeDamage(float damageAmount)
    {
        enemyHealth -= damageAmount;
=======
<<<<<<< HEAD
    // the following functions are called within animation events
    
    public void Charge()
    {
        isCharging = true;
        gameObject.tag = "Enemy_Charging";
=======
    public void TakeDamage(float damageAmount)
    {
        enemyHealth -= damageAmount;
>>>>>>> 6c1f16f42df958120d324e2bed590807675137c6
>>>>>>> Stashed changes
    }
}
