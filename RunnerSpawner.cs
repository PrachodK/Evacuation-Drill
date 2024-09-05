using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class RunnerSpawner : MonoBehaviour
{
    public int numRunners;
    public float initialWaitTime;
    private int numRunnersInQ;
    public GameObject runner;
    private Stack<int> numStack = new Stack<int>();

    private void Awake()
    {
        for (int i = 0; i < numRunners; i++)
            numStack.Push(i);
        foreach (var num in numStack)
            numRunnersInQ++;
    }

    private void Start()
    {
        InvokeRepeating("SpawnRunners", initialWaitTime, 0.2f);
    }


    private void SpawnRunners()
    {
        if (numRunnersInQ > 0)
        {
            Instantiate(runner, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            numRunnersInQ--;
        }
    }
}
