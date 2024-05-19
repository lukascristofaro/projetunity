using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    }
}