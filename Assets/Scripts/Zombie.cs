using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public NavMeshAgent navAgent;
    public int health = 100;
    public int bulletDamage = 33;

    private bool inLife = true;
    public Transform TargetPoint;
    private Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator not found on the Zombie prefab or its children.");
        }

        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            TargetPoint = player.transform;
        }
        else
        {
            Debug.LogError("Player not found in the scene.");
        }
    }

    private void Update()
    {
        if (inLife)
        {
            navAgent.SetDestination(TargetPoint.position);
        }
        else
        {
            navAgent.isStopped = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            getBulletDamage();
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Collision");
            Attack();
        }
    }

    void Attack()
    {
        if (animator != null)
        {
            animator.Play("Attack");
            navAgent.isStopped = true;
        }
        navAgent.isStopped = false;

    }

    private void getBulletDamage()
    {
        takeDamage(bulletDamage);
    }

    private void takeDamage(int damage)
    {
        if (health > 0)
        {
            health -= damage;
            if (health <= 0)
            {
                health = 0;
                inLife = false;

                Debug.Log("Zombie is dead.");
            }
        }
    }
}