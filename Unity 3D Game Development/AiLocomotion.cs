using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiLocomotion : MonoBehaviour
{
    public Transform playerTransform;
    public float maxResponseTime = 1.0f;
    public float maxDistance = 1.0f;

    UnityEngine.AI.NavMeshAgent agent;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        // On start, set player transform as agent's destination
        if(playerTransform == null)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }

        // Create a reference for the enemy AI object
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        // Create a reference for the animator
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Path finding algo based on Square Magnitude Method
        Vector3 direction = (playerTransform.position - agent.destination);
        direction.y = 0;
        if(direction.sqrMagnitude > maxDistance * maxDistance)
        {
            if(agent.pathStatus != UnityEngine.AI.NavMeshPathStatus.PathPartial)
            {
                // update path
                agent.destination = playerTransform.position;
            }
        }
    }
}
