using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunnerMovement : MonoBehaviour
{
    private Vector3 target;
    public GameObject targetObject;
    public GameObject targetObjectGate;
    public GameObject targetObjectOffice;
    public GameObject targetObjectBack;
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
        targetObject = GameObject.Find("Goal");
        targetObjectGate = GameObject.Find("Gate");
        targetObjectOffice = GameObject.Find("Office");
        targetObjectBack = GameObject.Find("Back");
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
            target.x = targetObject.transform.position.x;
            target.y = targetObject.transform.position.y;
            target.z = targetObject.transform.position.z;
        }
        else
        {
            if(dist1 <= dist2 && dist1 <= dist3)
            {
                target.x = targetObjectGate.transform.position.x;
                target.y = targetObjectGate.transform.position.y;
                target.z = targetObjectGate.transform.position.z;
            } 
            else if(dist2 <= dist1 && dist2 <= dist3)
            {
                target.x = targetObjectOffice.transform.position.x;
                target.y = targetObjectOffice.transform.position.y;
                target.z = targetObjectOffice.transform.position.z;
            }
            else if (dist3 <= dist1 && dist3 <= dist2)
            {
                target.x = targetObjectBack.transform.position.x;
                target.y = targetObjectBack.transform.position.y;
                target.z = targetObjectBack.transform.position.z;
            }
        }
    }

    void SetAgentPosition()
    {
        agent.SetDestination(new Vector3 (target.x, target.y, transform.transform.position.z));
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
