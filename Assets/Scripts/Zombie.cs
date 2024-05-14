using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    // Start is called before the first frame update
    public NavMeshAgent navAgent;

    public Transform TargetPoint;

    private void Update()
    {
        navAgent.SetDestination(TargetPoint.position);
    }
}
