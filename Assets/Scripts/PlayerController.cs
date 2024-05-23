using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int health = 100;
    private bool inLife = true;
    private CharacterController characterController;

    public Image redFilter;
    public float filterDuration = 0.1f;


    private void Start()
    {
        redFilter.enabled = false;

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
            StartCoroutine(ShowRedFilter());
        }
        else
        {
            health = 0;
            inLife = false;
        }


    }

    private IEnumerator ShowRedFilter()
    {
        redFilter.enabled = true;
        yield return new WaitForSeconds(filterDuration);
        redFilter.enabled = false;
    }

}