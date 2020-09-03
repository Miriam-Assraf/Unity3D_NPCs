using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMotion : MonoBehaviour
{
    public GameObject target;
    [SerializeField] float destinationReachedTreshold; 
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(target.transform.position);
        destinationReachedTreshold = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
        if (distanceToTarget < destinationReachedTreshold)
        {     
            GetComponent<Animation>().Play("Idle");
        }
        else
        {
            GetComponent<Animation>().Play("Female Walk");
        }
    }
}
