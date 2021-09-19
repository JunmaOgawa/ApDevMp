using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //player reference
    public Player player;
    public Transform playerTransform;
    public LayerMask whatIsPlayer;

    //parameters
    public float health;
    public int type; //0 = R, 1 = G, 2 = B
    public Rigidbody projectile;

    //color Materials
    public Material RedMaterial;
    public Material BlueMaterial;
    public Material GreenMaterial;
    //enemy rndererholder
    Renderer rend;

    //attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public float attackRange;
    public bool playerInAttackRange;

    //pointManager
    //public PointManager pointManager;

    private void Awake()
    {
        playerTransform = GameObject.Find("GameplayPlane").transform;//find player transform
        //parameters
        health = 3;//set health
        if (tag == "Boss") health = 20;
        type = Random.Range(0, 3);//set type

        timeBetweenAttacks = 2;
        attackRange = 30;

        //change color to type
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        if (type == 0) //red
        {
            rend.sharedMaterial = RedMaterial;
        }
        else if (type == 1) //green
        {
            rend.sharedMaterial = GreenMaterial;
        }
        else if (type == 2) //blue
        {
            rend.sharedMaterial = BlueMaterial;
        }
    }

    private void Update()
    {
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        if (playerInAttackRange) 
        {
            Debug.Log("Player is in range");
            AttackPlayer(); 
        }

        if(health <= 0)
        {
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().Play("Death");
            if(tag == "Boss") FindObjectOfType<PointManager>().AddBossPoints();
            else FindObjectOfType<PointManager>().AddPoints();
        }
    }

    private void AttackPlayer()
    {
        transform.LookAt(playerTransform);
        if (!alreadyAttacked)
        {
            //place attack code
            //need to change for space dimentions
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();

            rb.AddForce(transform.forward * 10.0f, ForceMode.Impulse);

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
                if (type == 0) health -= 3;
                else health--;
                Destroy(collision.gameObject);
                break;
            case "Green":
                if (type == 1) health -= 3;
                else health--;
                Destroy(collision.gameObject);
                break;
            case "Blue":
                if (type == 2) health -= 3;
                else health--;
                Destroy(collision.gameObject);
                break;
        }
        
    }



}
