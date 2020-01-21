using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Material material;
    public GameObject player;
    public int health = 10;
    public float speed = 10f;
    public float attackSpeed = 20f;

    Vector3 targetLocation;
    Vector3 playerPos;
    bool isAttacking = false;

    public GameObject dropPrefab;

    private float canAttackTimeStamp;

    public enum State
    {
        Idle,
        Attack,
        Retreat
    }

    private State state;

    void Start()
    {
        //world = GameObject.Find("World");
        targetLocation = transform.position;
        playerPos = player.transform.position;
        canAttackTimeStamp = Time.time + 5f;
        state = State.Idle;
    }

    void Update()
    {
        if (state == State.Idle)
        {
            //enemy idle and randomly decide to attack player
            material.color = new Color(0,0,1,1);
            Idle();
        }
        else if (state == State.Attack)
        {
            //attack player speed to player's current position and then retreat
            material.color = new Color(0, 1, 0, 1);
            Attack();
        }
        else if (state == State.Retreat)
        {
            //retreat to safe location the idle
            material.color = new Color(1, 0, 0, 1);
            Retreat();
        }

        if (canAttackTimeStamp <= Time.time)
        {
            int attackChance = Random.Range(0, 1000);
            //Debug.Log(attackChance);

            if (attackChance >= 990)
            {
                state = State.Attack;
                isAttacking = true;
                canAttackTimeStamp = Time.time + 5f;
            }
        }


    }

    private void Idle()
    {
        //look at player and move around spawn height randomly every x seconds
        if (transform.position == targetLocation)
        {
            targetLocation = new Vector3(Random.Range(-10, 10), Random.Range(0, 10), Random.Range(-10, 10));
        }
        transform.position = Vector3.MoveTowards(transform.position, targetLocation, speed * Time.deltaTime);

    }

    private void Attack()
    {
        if (isAttacking == true)
        {
            playerPos = player.transform.position;
            isAttacking = false;
        }

        //get players current position and attack
        if (transform.position == playerPos)
        {
            state = State.Retreat;
        }
        transform.position = Vector3.MoveTowards(transform.position, playerPos, attackSpeed * Time.deltaTime);



    }


    private void Retreat()
    {
        if (transform.position == targetLocation)
        {
            state = State.Idle;
        }
        transform.position = Vector3.MoveTowards(transform.position, targetLocation, speed * Time.deltaTime);
    }

    public void Damaged(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Death();
        }

    }

    private void Death()
    {
        //Instantiate(dropPrefab, transform.position, Quaternion.identity);
        //world.GetComponent<PortalController>().RemoveEnemy(gameObject);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //damage player
            //player.GetComponent<PlayerAbilities>().Damaged();
            state = State.Retreat;
        }
        else if (other.tag == "Projectile")
        {
            state = State.Retreat;
            Damaged(5);
        }

        if (other.tag == "Enemy")
        {
            state = State.Retreat;
        }

    }
}
