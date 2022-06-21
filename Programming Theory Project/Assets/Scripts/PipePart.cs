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
    public GameObject previousPipe;
    public GameObject nextPipe;
    RandomSpawn spawner;
    public bool isConnected;
    void Awake()
    {    
        orientation = "pos0";
    }
    
    public bool isAUsed;
    public bool isBUsed;
    public bool isCUsed;
    public bool isDUsed;

    // Start is called before the first frame update
    void Start()
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

    // Update is called once per frame
    void Update()
    {
        
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

    GridSquare a1;
    GridSquare a2;
    GridSquare a3;
    GridSquare b1;
    GridSquare b2;
    GridSquare b3;
    GridSquare c1;
    GridSquare c2;
    GridSquare c3;
    
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
            partUp = a1.occupyingPart;
            CheckingUp();
        }
        if (currentSquare.name == "SquareB2")
        {
            partUp = a2.occupyingPart;
            CheckingUp();
        }
        if (currentSquare.name == "SquareB3")
        {
            partUp = a3.occupyingPart;
            CheckingUp();
        }
        if (currentSquare.name == "SquareC1")
        {
            partUp = b1.occupyingPart;
            CheckingUp();
        }
        if (currentSquare.name == "SquareC2")
        {
            partUp = b2.occupyingPart;
            CheckingUp();
        }
        if (currentSquare.name == "SquareC3")
        {
            partUp = b3.occupyingPart;
            CheckingUp();
        }
    }

    void CheckingUp()
    {
        if (partUp = null)
        {
            isConnected = false;
            Debug.Log(name + " at " + currentSquare.name + " is not connected");
        }
        else if (partUp.GetComponent<PipePart>().isCUsed == true)
        {
            isConnected = true;
            Debug.Log(name + " at " + currentSquare.name + " is connected");
            partUp.GetComponent<PipePart>().LookForConnections();
        }
    }

    protected void CheckRight()
    {
        if (currentSquare.name == "SquareA1")
        {
            partRight = a2.occupyingPart;
            CheckingRight();
        }
        if (currentSquare.name == "SquareA2")
        {
            partRight = a3.occupyingPart;
            CheckingRight();
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
            partRight = b2.occupyingPart;
            CheckingRight();
        }
        if (currentSquare.name == "SquareB2")
        {
            partRight = b3.occupyingPart;
            CheckingRight();
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
            partRight = c2.occupyingPart;
            CheckingRight();   
        }
        if (currentSquare.name == "SquareC2")
        {
            partRight = c3.occupyingPart;
            CheckingRight();  
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
    void CheckingRight()
    {
        if (partRight = null)
        {
            isConnected = false;
        } 
        else if (partRight.GetComponent<PipePart>().isDUsed == true)
        {
            isConnected = true;
            Debug.Log(name + " at " + currentSquare.name + " is connected");
            partRight.GetComponent<PipePart>().LookForConnections();
        } 
          
    }

    protected void CheckDown()
    {
        if (currentSquare.name == "SquareA1")
        {
            partDown = b1.occupyingPart;
            CheckingDown();
        }
        if (currentSquare.name == "SquareA2")
        {
            partDown = b2.occupyingPart;
            CheckingDown();
        }
        if (currentSquare.name == "SquareA3")
        {
            partDown = b3.occupyingPart;
            CheckingDown();
        }
        if (currentSquare.name == "SquareB1")
        {
            partDown = c1.occupyingPart;
            CheckingDown();
        }
        if (currentSquare.name == "SquareB2")
        {
            partDown = c2.occupyingPart;
            CheckingDown();
        }
        if (currentSquare.name == "SquareB3")
        {
            partDown = c3.occupyingPart;
            CheckingDown();
        }
        if (currentSquare.name == "SquareC1" || currentSquare.name == "SquareC2" || currentSquare.name == "SquareC3")
        {
            partDown = null;
            Debug.Log("No downwards connection for " + name + " at " + currentSquare.name);
        }
    }

    void CheckingDown()
    {
        if (partDown = null)
        {
            isConnected = false;
        } 
        else if (partDown.GetComponent<PipePart>().isAUsed == true)
        {
            isConnected = true;
            Debug.Log(name + " at " + currentSquare.name + " is connected");
            partDown.GetComponent<PipePart>().LookForConnections();
        } 
          
    }

    protected void CheckLeft()
    {
        if (currentSquare.name == "SquareA1")
        {
            if (spawner.startIndex == 0)
            {
                Debug.Log(name + " at " + currentSquare.name + " is connected to start");
            }
            else
            {
                Debug.Log("No left connection for " + name + " at " + currentSquare.name);
            }
        }
        if (currentSquare.name == "SquareA2")
        {
            partLeft = a1.occupyingPart;
            CheckingLeft();
        }
        if (currentSquare.name == "SquareA3")
        {
            partLeft = a2.occupyingPart;
            CheckingLeft();     
        }
        if (currentSquare.name == "SquareB1")
        {
            if (spawner.startIndex == 1)
            {
                Debug.Log(name + " at " + currentSquare.name + " is connected to start");
            }
            else
            {
                Debug.Log("No left connection for " + name + " at " + currentSquare.name);
            }
        }
        if (currentSquare.name == "SquareB2")
        {
            partLeft = b1.occupyingPart;
            CheckingLeft();
        }
        if (currentSquare.name == "SquareB3")
        {
            partLeft = b2.occupyingPart;
            CheckingLeft();
        }
        if (currentSquare.name == "SquareC1")
        {
            if (spawner.startIndex == 2)
            {
                Debug.Log(name + " at " + currentSquare.name + " is connected to start");
            }
            else
            {
                Debug.Log("No left connection for " + name + " at " + currentSquare.name);
            }
        }
        if (currentSquare.name == "SquareC2")
        {
            partLeft = c1.occupyingPart;
            CheckingLeft();
        }
        if (currentSquare.name == "SquareC3")
        {
            partLeft = c2.occupyingPart;
            CheckingLeft();   
        }
    }

    void CheckingLeft()
    {
        if (partLeft = null)
        {
            isConnected = false;
        }
        else if (partLeft.GetComponent<PipePart>().isBUsed == true)
        {
            isConnected = true;
            Debug.Log(name + " at " + currentSquare.name + " is connected");
            partLeft.GetComponent<PipePart>().LookForConnections();
        } 
        
    }
    
    void CheckEnd()
    {
        var endPart = GameObject.Find("PipeEnd").GetComponent<PipeEnd>();
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