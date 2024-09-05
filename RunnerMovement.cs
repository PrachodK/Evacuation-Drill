using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunnerMovement : MonoBehaviour
{
    private Vector3 target;
    public Transform targetObject;
    public Transform targetObjectGate;
    public Transform targetObjectOffice;
    public Transform targetObjectBack;
    private float dist1;
    private float dist2;
    private float dist3;
    public bool betterSim = false;
    NavMeshAgent agent;

    private void Awake()
    { 
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        dist1 = Vector3.Distance(agent.transform.position, targetObjectGate.transform.position);
        dist2 = Vector3.Distance(agent.transform.position, targetObjectOffice.transform.position);
        dist3 = Vector3.Distance(agent.transform.position, targetObjectBack.transform.position);
    }

    void Update()
    {
        SetTargetPosition(betterSim);
        SetAgentPosition();
    }

    void SetTargetPosition(bool betterSimulation)
    {
        if(!betterSimulation)
        {
            target.x = targetObject.position.x;
            target.y = targetObject.position.y;
            target.z = targetObject.position.z;
        }
        else
        {
            if(dist1 <= dist2 && dist1 <= dist3)
            {
                target.x = targetObjectGate.position.x;
                target.y = targetObjectGate.position.y;
                target.z = targetObjectGate.position.z;
            } 
            else if(dist2 <= dist1 && dist2 <= dist3)
            {
                target.x = targetObjectOffice.position.x;
                target.y = targetObjectOffice.position.y;
                target.z = targetObjectOffice.position.z;
            }
            else if (dist3 <= dist1 && dist3 <= dist2)
            {
                target.x = targetObjectBack.position.x;
                target.y = targetObjectBack.position.y;
                target.z = targetObjectBack.position.z;
            }
        }
    }

    void SetAgentPosition()
    {
        agent.SetDestination(new Vector3 (target.x, target.y, transform.position.z));
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Slow")
            agent.speed = 0.3f;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Slow")
            agent.speed = 0.5f;
    }
}
