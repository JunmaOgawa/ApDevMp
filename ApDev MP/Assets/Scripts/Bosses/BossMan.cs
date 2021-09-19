using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMan : MonoBehaviour
{
    //player reference
    public Player player;
    public Transform playerTransform;
    public LayerMask whatIsPlayer;

    //parameters
    public int health;
    public int type; //0 = R, 1 = G, 2 = B

    //attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public float attackRange;
    public bool playerInAttackRange;

    public Animator animator;

    public HealthBar healthbar;

    private void Awake()
    {
        playerTransform = GameObject.Find("GameplayPlane").transform;//find player transform
        //parameters
        health = 40;//set health
        type = 2;//set type

        timeBetweenAttacks = 20f;
        attackRange = 10000;

        healthbar.SetMaxHealth(health);
    }

    private void Update()
    {
        //playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        playerInAttackRange = true;
        if (playerInAttackRange)
        {
            Debug.Log("Player is in range");
            AttackPlayer();
        }

        if (health <= 0)
        {
            animator.SetTrigger("onDeath");
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().Play("Death");
        }
        healthbar.SetHealth(health);
    }

    private void AttackPlayer()
    {
        transform.LookAt(playerTransform);
        if (!alreadyAttacked)
        {
            animator.SetTrigger("onAttack");
            player.HP -= 5;
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        FindObjectOfType<AudioManager>().Play("Hit");
        switch (collision.collider.tag)
        {
            case "Player":
                player.GotHit();
                break;
            case "Red":
                if (type == 0) health -= 4;
                else health--;
                animator.SetTrigger("onDamaged");
                Destroy(collision.gameObject);
                break;
            case "Green":
                if (type == 1) health -= 4;
                else health--;
                animator.SetTrigger("onDamaged");
                Destroy(collision.gameObject);
                break;
            case "Blue":
                if (type == 2) health -= 4;
                else health--;
                animator.SetTrigger("onDamaged");
                Destroy(collision.gameObject);
                break;
        }

    }
}
