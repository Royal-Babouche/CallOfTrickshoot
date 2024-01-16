using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveEsclave : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Vector3 _destination;

    public void SetDestination(Vector3 destination)
    {
        _destination = destination;
        _agent.SetDestination(_destination);
    }
}
