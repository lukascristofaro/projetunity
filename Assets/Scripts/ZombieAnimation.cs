using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimation : MonoBehaviour
{
    Animator zombieAnimator;
    [SerializeField] float speed = 1f;

    private void Awake()
    {
        zombieAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        float v = Input.GetAxis("Vertical");
        zombieAnimator.SetFloat("MoveSpeed", v);
    }
}
