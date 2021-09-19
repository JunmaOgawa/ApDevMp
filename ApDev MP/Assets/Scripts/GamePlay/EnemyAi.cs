using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    //public NavMeshAgent agent;
    //public Transform agent;

    public float health;
    public int type; //0 = R, 1 = G, 2 = B
    public Material RedMaterial;
    public Material BlueMaterial;
    public Material GreenMaterial;
    //public MeshRenderer EnemyMeshRenderer;
    Renderer rend;    

    public Transform player;

    public LayerMask whatIsPlayer;

    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    public float attackRange; // ,sightRange
    public bool playerInAttackRange;

    

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        type = Random.Range(0,3);
        health = 3;

        timeBetweenAttacks = 3;
        attackRange = 15;

        rend = GetComponent<Renderer>();
        rend.enabled = true;
        if(type == 0) //red
        {
            rend.sharedMaterial = RedMaterial;
        }
        else if(type == 1) //green
        {
            rend.sharedMaterial = GreenMaterial;
        }
        else if(type == 2) //blue
        {
            rend.sharedMaterial = BlueMaterial;
        }
        //agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (playerInAttackRange) AttackPlayer();
    }
    private void AttackPlayer()
    {
        transform.LookAt(player);
        if(!alreadyAttacked)
        {
            //place attack code
            //need to change for space dimentions
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(DestroyEnemy), .5f);
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
        FindObjectOfType<AudioManager>().Play("Death");
        // FindObjectOfType<PointManager>().AddPoints();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
