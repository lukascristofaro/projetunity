using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int health = 100;
    private bool inLife = true;
    private CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (!inLife)
        {
            characterController.enabled = false;
            return;
        }

        characterController.enabled = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            getDamage(10);
        }
    }

    private void getDamage(int damage)
    {
        if (health > 0)
        {
            health -= damage;
        }
        else
        {
            health = 0;
            inLife = false;
        }
    }

}