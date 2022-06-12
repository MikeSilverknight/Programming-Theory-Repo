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
        if (partUp.GetComponent<PipePart>().isCUsed == true)
        {
            isConnected = true;
            Debug.Log(name + " at " + currentSquare.name + " is connected");
            partUp.GetComponent<PipePart>().LookForConnections();
        } else
        {
            isConnected = false;
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
        if (currentSquare.name == "SquareA3" && spawner.endIndex == 0)
        {
            
            
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
        if (currentSquare.name == "SquareB3" && spawner.endIndex == 1)
        {
            
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
        if (currentSquare.name == "SquareC3" && spawner.endIndex == 2)
        {
            
            
        }
    }
    void CheckingRight()
    {
        if (partRight.GetComponent<PipePart>().isDUsed == true)
        {
            isConnected = true;
            Debug.Log(name + " at " + currentSquare.name + " is connected");
            partRight.GetComponent<PipePart>().LookForConnections();
        } else
        {
            isConnected = false;
        }   
    }
    protected void CheckDown()
    {
        if (currentSquare.name == "SquareA1")
        {
            
        }
        if (currentSquare.name == "SquareA2")
        {
            
        }
        if (currentSquare.name == "SquareA3")
        {
            
        }
        if (currentSquare.name == "SquareB1")
        {
            
        }
        if (currentSquare.name == "SquareB2")
        {
            
        }
        if (currentSquare.name == "SquareB3")
        {
            
        }
        if (currentSquare.name == "SquareC1" || currentSquare.name == "SquareC2" || currentSquare.name == "SquareC3")
        {
            
        }
    }

    protected void CheckLeft()
    {
        
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