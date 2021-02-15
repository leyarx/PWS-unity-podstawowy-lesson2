using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyControl : MonoBehaviour
{
    public Transform player;
    NavMeshAgent agent;
    Vector3 destination;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        destination = agent.destination;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(destination, player.position) > 1.0f)
        {
            destination = player.position;
            agent.destination = destination;
        }
    }
}
