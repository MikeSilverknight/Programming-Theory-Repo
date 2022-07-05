using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PipeEnd : MonoBehaviour
{
    public bool isConnected;
    public GameObject previousPipe;
    private GridSquare previousSquare;
    private RandomSpawn pipeSpawner;
    [SerializeField] private UserControl controller; // ENCAPSULATION

    // Start is called before the first frame update
    void Start()
    {
        isConnected = false;
        pipeSpawner = GameObject.Find("GridManager").GetComponent<RandomSpawn>();
        controller = GameObject.Find("Controller").GetComponent<UserControl>();
        FindLocation(); // ABSTRACTION
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FindLocation()
    {
        if (pipeSpawner.endIndex == 0)
        {
            previousSquare = GameObject.Find("SquareA3").GetComponent<GridSquare>();
        }
        if (pipeSpawner.endIndex == 1)
        {
            previousSquare = GameObject.Find("SquareB3").GetComponent<GridSquare>();
        }
        if (pipeSpawner.endIndex == 2)
        {
            previousSquare = GameObject.Find("SquareC3").GetComponent<GridSquare>();
        }
    }

    public void FindConnection()    
    {
        if (previousSquare.occupyingPart != null && previousPipe == previousSquare.occupyingPart)
        {
            var prev = previousPipe.GetComponent<PipePart>();
        
            if (prev.isBUsed == true && prev.isConnected == true)
            {
                isConnected = true;
                Debug.Log("Start and End are Connected!");
                StartCoroutine(controller.GetComponent<UserControl>().WinGame());
            } 
            else
            {
                isConnected = false;
                Debug.Log("No connection");
            }
        }   
    }
}
