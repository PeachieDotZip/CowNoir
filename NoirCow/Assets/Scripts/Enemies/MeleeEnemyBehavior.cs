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
    private bool isDazed;

    //make the target a variable 
    //target object = null then it's the player?

    public float currentSpeed;

    public Transform player;
    public Transform target;

    public float enemyHealth = 3;


    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        canCharge = false;
        isCharging = false;

        StartCoroutine(delayCharge());

        if (canCharge)
        {
            moveEnemy();
        }

        StopCoroutine(delayCharge());
    }

    void Update()
    {
        disToPlayer = Vector2.Distance(transform.position, player.position);

        //currentSpeed =  Mathf.Abs(rb2d.velocity.x);

        if (!isCharging)
        {
            if (disToPlayer <= range)
            {
                canCharge = true;
                moveEnemy();
            }
        }

        if (isDazed)
        {
            moveSpeed = 0;
            canCharge = true;
            isCharging = false;
        }

        else
        {
            StartCoroutine(delayCharge());
        }

        /*
        if (storedPositions[storedPositions.Count - 1] != player.transform.position) 
        {
            storedPositions.Add(player.transform.position); //stores the position every frame
        }
        */
    }


    private void targetPlayer()
    {
        //moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;        
    }

    private void moveEnemy()
    {
        if (isCharging)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, target.position, moveSpeed * Time.deltaTime);
        }
    }

    IEnumerator delayCharge()
    {
        Debug.Log("Delay Charge Started");
        //Play animation
        yield return new WaitForSeconds(chargeDelayTime);
        {
            canCharge = true;
            isCharging = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall") || collision.CompareTag("Player"))
        {
            StartCoroutine(DazeDuration());
        }
    }

    private IEnumerator DazeDuration()
    {
        isDazed = true;
        yield return new WaitForSeconds(3.5f);
        isDazed = false;
    }

    /// <summary>
    /// Draws the range so it can be easily tested in the scene view.
    /// </summary>
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public void TakeDamage(float damageAmount)
    {
        enemyHealth -= damageAmount;
    }
}
