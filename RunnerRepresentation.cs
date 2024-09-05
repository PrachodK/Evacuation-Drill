using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerRepresentation : MonoBehaviour
{
    public GameObject runner;
    private int randomColorNum;


    void Start()
    {
        randomColorNum = Random.Range(1, 5);

        if (randomColorNum == 1)
            runner.GetComponent<SpriteRenderer>().color = Color.cyan;
        else if (randomColorNum == 2)
            runner.GetComponent<SpriteRenderer>().color = Color.magenta;
        else if (randomColorNum == 3)
            runner.GetComponent<SpriteRenderer>().color = Color.yellow;
        else if (randomColorNum == 4)
            runner.GetComponent<SpriteRenderer>().color = Color.green;
    }
}
