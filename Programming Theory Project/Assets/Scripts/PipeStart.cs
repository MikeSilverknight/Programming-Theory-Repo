using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeStart : MonoBehaviour
{
    public bool isConnected;
    public GameObject nextPipe = null;
    public GridSquare nextSquare = null;
    public RandomSpawn pipeSpawner;

    // Start is called before the first frame update
    void Start()
    {
        isConnected = false;
        pipeSpawner = GameObject.Find("GridManager").GetComponent<RandomSpawn>();
        FindStartLocation();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FindStartLocation()
    {
        if (pipeSpawner.startIndex == 0)
        {
            nextSquare = GameObject.Find("SquareA1").GetComponent<GridSquare>();
        }
        if (pipeSpawner.startIndex == 1)
        {
            nextSquare = GameObject.Find("SquareB1").GetComponent<GridSquare>();
        }
        if (pipeSpawner.startIndex == 2)
        {
            nextSquare = GameObject.Find("SquareC1").GetComponent<GridSquare>();
        }
    }

    public void FindStartConnection()    
    {
        if (nextSquare.occupyingPart != null)
        {
            nextPipe = nextSquare.occupyingPart;
            var next = nextPipe.GetComponent<PipePart>();
            
            if (next.isDUsed == true)
            {
                isConnected = true;
                Debug.Log(nextPipe.name + " is Connected!");
                next.previousPipe = this.gameObject;
                next.LookForConnections();
            } else
            {
                isConnected = false;
                Debug.Log("No connection");
            }
        } else if (nextSquare.occupyingPart == null)
        {
            Debug.Log("No connection");
        }
        
        
    }
}
