using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeStart : MonoBehaviour
{
    public bool isConnected;
    GameObject connectedPipe;
    GridSquare connectedSquare;
    RandomSpawn pipeSpawner;

    // Start is called before the first frame update
    void Start()
    {
        isConnected = false;
        pipeSpawner = GameObject.Find("GridManager").GetComponent<RandomSpawn>();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FindLocation()
    {
        if (pipeSpawner.startIndex == 0)
        {
            connectedSquare = GameObject.Find("SquareA1").GetComponent<GridSquare>();
        }
        if (pipeSpawner.startIndex == 1)
        {
            connectedSquare = GameObject.Find("SquareB1").GetComponent<GridSquare>();
        }
        if (pipeSpawner.startIndex == 2)
        {
            connectedSquare = GameObject.Find("SquareC1").GetComponent<GridSquare>();
        }

    }

    public void FindConnection()    
    {
        if (connectedSquare.occupyingPart != null)
        {
            connectedPipe = connectedSquare.occupyingPart;
        }
        
        if (connectedPipe.GetComponent<PipePart>().isDUsed == true)
        {
            isConnected = true;
            Debug.Log(connectedPipe.name + " is Connected!");
        } else
        {
            isConnected = false;
        }
        
    }
}
