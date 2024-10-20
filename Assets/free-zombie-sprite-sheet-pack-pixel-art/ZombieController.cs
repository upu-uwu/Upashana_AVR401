using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public Transform playerTarget;
    [SerializeField] private float speed = 2;
    SpriteRenderer spriteRenderer;
    Animator animatorController; // Add reference to Animator

    [SerializeField] private float chaseDistance = 3f;
    [SerializeField] private float attackDistance = 4.5f;
    float timer = 0;
    public gameManager gameM;
    public float damage = 5f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animatorController = GetComponent<Animator>(); // Assign Animator component
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, playerTarget.position) <= attackDistance)
        {
            attackState();
        }
        else if (Vector2.Distance(transform.position, playerTarget.position) <= chaseDistance)
        {
            chaseState();
        }
        else
        {
            idleState();
        }
    }

    void attackState()
    {
        timer += Time.deltaTime;
        Debug.Log("Timer : " + timer);

        if ((int)timer == 2)
        {
            gameM.PlayerHit(damage);
            Debug.Log("Hit");
            timer = 0;

        }
    }

    //StateMachine
    void idleState()
    {
        animatorController.SetInteger("enemyAni", 0);
    }
    void chaseState()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerTarget.position, speed * Time.deltaTime);

        // Check distance and set animation based on chase distance threshold
        float distanceToPlayer = Vector2.Distance(transform.position, playerTarget.position);
        animatorController.SetInteger("enemyAni", 1);

        if (playerTarget.position.x < transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseDistance);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackDistance);
    }
}