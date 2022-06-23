using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Master class for piping components.
/// </summary>
public abstract class PipePart : MonoBehaviour
{
    public string orientation {get; private set;}
    public GameObject currentSquare;
    RandomSpawn spawner;
    public bool isConnected;

    GridSquare a1;
    GridSquare a2;
    GridSquare a3;
    GridSquare b1;
    GridSquare b2;
    GridSquare b3;
    GridSquare c1;
    GridSquare c2;
    GridSquare c3;
    void Awake()
    {    
        orientation = "pos0";
        PingObjects();
    }
    
    public bool isAUsed;
    public bool isBUsed;
    public bool isCUsed;
    public bool isDUsed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PingObjects()
    {
        spawner = GameObject.Find("GridManager").GetComponent<RandomSpawn>();
        a1 = GameObject.Find("SquareA1").GetComponent<GridSquare>();
        a2 = GameObject.Find("SquareA2").GetComponent<GridSquare>();
        a3 = GameObject.Find("SquareA3").GetComponent<GridSquare>();
        b1 = GameObject.Find("SquareB1").GetComponent<GridSquare>();
        b2 = GameObject.Find("SquareB2").GetComponent<GridSquare>();
        b3 = GameObject.Find("SquareB3").GetComponent<GridSquare>();
        c1 = GameObject.Find("SquareC1").GetComponent<GridSquare>();
        c2 = GameObject.Find("SquareC2").GetComponent<GridSquare>();
        c3 = GameObject.Find("SquareC3").GetComponent<GridSquare>();
    }

    public void Orientate()
    {
        if (orientation == "pos0")
        {
            orientation = "pos1";
        }  
        else if (orientation == "pos1")
        {
            orientation = "pos2";
        }  
        else if (orientation == "pos2")
        {
            orientation = "pos3";
        }
        else if (orientation == "pos3")
        {
            orientation = "pos0";
        }    
    }

    public abstract void LookForConnections();
    
    GameObject partUp;
    GameObject partRight;
    GameObject partDown;
    GameObject partLeft;
    
    protected void CheckUp()
    {
        if (currentSquare.name == "SquareA1" || currentSquare.name == "SquareA2" || currentSquare.name == "SquareA3")
        {
            partUp = null;
            Debug.Log("No upwards connection for " + name + " at " + currentSquare.name);
        }
        if (currentSquare.name == "SquareB1")
        {
            CheckingUp(a1);
        }
        if (currentSquare.name == "SquareB2")
        {
            CheckingUp(a2);
        }
        if (currentSquare.name == "SquareB3")
        {
            CheckingUp(a3);
        }
        if (currentSquare.name == "SquareC1")
        {
            CheckingUp(b1);
        }
        if (currentSquare.name == "SquareC2")
        {
            CheckingUp(b2);
        }
        if (currentSquare.name == "SquareC3")
        {
            CheckingUp(b3);
        }
    }

    void CheckingUp(GridSquare squareU)
    {
        if (squareU.isOccupied == true)
        {
            partUp = squareU.occupyingPart;
            if (partUp.GetComponent<PipePart>().isCUsed == true)
            {
                Debug.Log(partUp.name + " at " + squareU.name + " is connected");
                FeedbackFilter(partUp);   
            }
            else
            {
                Debug.Log(partUp.name + " at " + squareU.name + " is not connected");
            }
        }
        else if (squareU.isOccupied == false)
        {
            partUp = null;
            Debug.Log(name + " at " + currentSquare.name + " has no connection");
        }
    }

    protected void CheckRight()
    {
        if (currentSquare.name == "SquareA1")
        {
            CheckingRight(a2);
        }
        if (currentSquare.name == "SquareA2")
        {
            CheckingRight(a3);
        }
        if (currentSquare.name == "SquareA3")
        {
            if (spawner.endIndex == 0)
            {
                CheckEnd();
            }
            else
            {
                Debug.Log("No right connection for " + name + " at " + currentSquare.name);
            }
        }
        if (currentSquare.name == "SquareB1")
        {
            CheckingRight(b2);
        }
        if (currentSquare.name == "SquareB2")
        {
            CheckingRight(b3);
        }
        if (currentSquare.name == "SquareB3")
        {
            if (spawner.endIndex == 1)
            {
                CheckEnd();
            }
            else
            {
                Debug.Log("No right connection for " + name + " at " + currentSquare.name);
            }
        }
        if (currentSquare.name == "SquareC1")
        {
            CheckingRight(c2);   
        }
        if (currentSquare.name == "SquareC2")
        {
            CheckingRight(c3);  
        }
        if (currentSquare.name == "SquareC3")
        {
            if (spawner.endIndex == 2)
            {
                CheckEnd();
            }
            else
            {
                Debug.Log("No right connection for " + name + " at " + currentSquare.name);
            } 
        }
    }
    void CheckingRight(GridSquare squareR)
    {
        if (squareR.isOccupied == true)
        {
            partRight = squareR.occupyingPart;
            if (partRight.GetComponent<PipePart>().isDUsed == true)
            {
                Debug.Log(partRight.name + " at " + squareR.name + " is connected");
                FeedbackFilter(partRight);
            }
            else
            { 
                Debug.Log(partRight.name + " at " + squareR.name + " is not connected");
            }
        }
        else if (squareR.isOccupied == false)
        {
            partRight = null;
            Debug.Log(name + " at " + currentSquare.name + " has no connection");
        } 
    }

    protected void CheckDown()
    {
        if (currentSquare.name == "SquareA1")
        {
            CheckingDown(b1);
        }
        if (currentSquare.name == "SquareA2")
        {
            CheckingDown(b2);
        }
        if (currentSquare.name == "SquareA3")
        {
            CheckingDown(b3);
        }
        if (currentSquare.name == "SquareB1")
        {
            CheckingDown(c1);
        }
        if (currentSquare.name == "SquareB2")
        {
            CheckingDown(c2);
        }
        if (currentSquare.name == "SquareB3")
        {
            CheckingDown(c3);
        }
        if (currentSquare.name == "SquareC1" || currentSquare.name == "SquareC2" || currentSquare.name == "SquareC3")
        {
            partDown = null;
            Debug.Log("No downwards connection for " + name + " at " + currentSquare.name);
        }
    }

    void CheckingDown(GridSquare squareD)
    {
        if (squareD.isOccupied == true)
        {
            partDown = squareD.occupyingPart;
            if (partDown.GetComponent<PipePart>().isAUsed == true)
            {
                Debug.Log(partDown.name + " at " + squareD.name + " is connected");
                FeedbackFilter(partDown);
            }
            else
            { 
                Debug.Log(partDown.name + " at " + squareD.name + " is not connected");
            }
        }
        else if (squareD.isOccupied == false)
        {
            partDown = null;
            Debug.Log(name + " at " + currentSquare.name + " has no connection");
        }
    }

    protected void CheckLeft()
    {
        if (currentSquare.name == "SquareA1")
        {
            if (spawner.startIndex != 0)
            {
                Debug.Log("No left connection for " + name + " at " + currentSquare.name);
            }
        }
        if (currentSquare.name == "SquareA2")
        {
            CheckingLeft(a1);
        }
        if (currentSquare.name == "SquareA3")
        {
            CheckingLeft(a2);     
        }
        if (currentSquare.name == "SquareB1")
        {
            if (spawner.startIndex != 1)
            {
                Debug.Log("No left connection for " + name + " at " + currentSquare.name);
            }
        }
        if (currentSquare.name == "SquareB2")
        {
            CheckingLeft(b1);
        }
        if (currentSquare.name == "SquareB3")
        {
            CheckingLeft(b2);
        }
        if (currentSquare.name == "SquareC1")
        {
            if (spawner.startIndex != 2)
            {
                Debug.Log("No left connection for " + name + " at " + currentSquare.name);
            }
        }
        if (currentSquare.name == "SquareC2")
        { 
            CheckingLeft(c1);
        }
        if (currentSquare.name == "SquareC3")
        {
            CheckingLeft(c2);   
        }
    }

    void CheckingLeft(GridSquare squareL)
    {
        if (squareL.isOccupied == true)
        {
            partLeft = squareL.occupyingPart;
            if (partLeft.GetComponent<PipePart>().isBUsed == true)
            {
                Debug.Log(partLeft.name + " at " + squareL.name + " is connected");
                FeedbackFilter(partLeft);
            }
            else
            { 
                Debug.Log(partLeft.name + " at " + squareL.name + " is not connected");
            }
        }
        else if (squareL.isOccupied == false)
        {
            partUp = null;
            Debug.Log(name + " at " + currentSquare.name + " has no connection");
        }
    }
    
    //This should fix a vexing memory allocation loop where pipes would infinitly trigger each other
    void FeedbackFilter(GameObject other)
    {
        if (other.GetComponent<PipePart>().isConnected != true)
        {
            other.GetComponent<PipePart>().isConnected = true;        
            other.GetComponent<PipePart>().LookForConnections();
        }

    }

    void CheckEnd()
    {
        var endPart = GameObject.Find("PipeEnd(Clone)").GetComponent<PipeEnd>();
        endPart.FindConnection();
    }

    public virtual string GetPartName()
    {
        return "Part";
    }
    
    public string GetCategory() // POLYMORPHISM
    {
        return "Pipe";
    }
    
    
/// <summary>
/// Triggered every time a pipe rotates
/// </summary>
    public abstract void RotationDetector();
}