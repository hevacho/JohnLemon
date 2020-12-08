using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;

    public Transform[] waypoints;

    private int currentWayPointIndex = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.SetDestination(waypoints[0].position);
    }

    // Update is called once per frame
    void Update()
    {
        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        {
            currentWayPointIndex = (currentWayPointIndex + 1) % waypoints.Length;
            _navMeshAgent.SetDestination(waypoints[currentWayPointIndex].position);
        }   
    }
}
