using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Subclass for the L-Pipe.
/// </summary>
public class Pipe_L : PipePart // INHERITANCE
{   
    public override string GetPartName() // POLYMORPHISM
    {
        return "L-Pipe";
    }
    
    void Start()
    {  
        RotationDetector(); // ABSTRACTION
    }

    void Update()
    {

    }

    public override void RotationDetector()
    {
        
        if (orientation == "pos0")
        {
            isAUsed = true;
            isBUsed = false;
            isCUsed = false;
            isDUsed = true;
        }  
        else if (orientation == "pos1")
        {
            isAUsed = true;
            isBUsed = true;
            isCUsed = false;
            isDUsed = false;
        }
        else if (orientation == "pos2")
        {
            isAUsed = false;
            isBUsed = true;
            isCUsed = true;
            isDUsed = false;
        }
        else if (orientation == "pos3")
        {
            isAUsed = false;
            isBUsed = false;
            isCUsed = true;
            isDUsed = true;
        }   
    }

    public override void LookForConnections()
    {   
        if (orientation == "pos0")
        {
            CheckUp();
            CheckLeft();
        }
        else if (orientation == "pos1")
        {
            CheckUp();
            CheckRight();
        }  
        else if (orientation == "pos2")
        {
            CheckRight();
            CheckDown();
        }
        else if (orientation == "pos3")
        {
            CheckDown();
            CheckLeft();
        }   
    }
}