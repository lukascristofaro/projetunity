using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject impactPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("limitMap"))
        {
            return;
        }

        if (!collision.gameObject.CompareTag("Zombie"))
        {
            Destroy(gameObject);

            Vector3 collisionNormal = collision.contacts[0].normal;

            Quaternion rotation = Quaternion.FromToRotation(Vector3.forward, collisionNormal);

            GameObject impact = Instantiate(impactPrefab, collision.contacts[0].point, rotation);
            Destroy(impact, 10f);
        }
        else
        {
            // G�rer la collision avec le zombie sans lui appliquer de recul
            Rigidbody zombieRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            if (zombieRigidbody != null)
            {
                zombieRigidbody.velocity = Vector3.zero; // Annuler toute force appliqu�e
                zombieRigidbody.angularVelocity = Vector3.zero; // Annuler toute rotation appliqu�e
            }

            Destroy(gameObject);
        }
    }
}