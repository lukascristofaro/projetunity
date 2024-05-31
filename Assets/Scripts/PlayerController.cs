using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int health = 100;
    public int maxHealth = 100;
    public static bool inLife = true;
    public static int score = 0;
    private CharacterController characterController;

    public Image redFilter;
    public float filterDuration = 0.1f;


    private void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
        Debug.Log(inLife);
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
        if (health > 10)
        {
            health -= damage;
            StartCoroutine(ShowRedFilter());
        }
        else
        {
            health = 0;
            inLife = false;
            DeathMenu.DeathInput();

        }


    }

    private IEnumerator ShowRedFilter()
    {
        redFilter.enabled = true;
        yield return new WaitForSeconds(filterDuration);
        redFilter.enabled = false;
    }

}