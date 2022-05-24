using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sub-subclass for the L-Pipe.
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
}
