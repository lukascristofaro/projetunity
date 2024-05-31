using UnityEngine.AI;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public NavMeshAgent navAgent;
    public int health = 100;
    public int bulletDamage = 33;

    private bool inLife = true;
    public Transform TargetPoint;
    private Animator animator;


    void Start()
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
            animator.SetFloat("MoveSpeed", 1f);
        }
        else
        {
            Debug.LogError("Player not found in the scene.");
        }
    }

    void Update()
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

    void OnCollisionEnter(Collision collision)
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
            animator.SetFloat("MoveSpeed", 0f);

            animator.SetBool("Attack", true);
            Debug.Log("Zombie attack");
            animator.GetCurrentAnimatorStateInfo(0).IsName("Attack");
            animator.SetFloat("MoveSpeed", 1f);

        }
    }

    void Death()
    {
        health = 0;
        inLife = false;
        Debug.Log("Zombie is dead");
        animator.SetFloat("MoveSpeed", 0f);

        animator.SetBool("Dead", true) ;
        Destroy(gameObject, 2f);
        PlayerController.score += 100;
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
                Death();
            }
        }
    }
}