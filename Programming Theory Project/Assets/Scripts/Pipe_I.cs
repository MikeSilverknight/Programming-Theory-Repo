using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sub-subclass for the I-Pipe.
/// </summary>
public class Pipe_I : PipePart // INHERITANCE
{
    
    public float directionFaced {get; private set;} // ENCAPSULATION

    public override string GetPartName() // POLYMORPHISM
    {
        return "I-Pipe";
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
        
        if (orientation == "pos0" || orientation == "pos2")
        {
            isAUsed = true;
            isBUsed = false;
            isCUsed = true;
            isDUsed = false;
        }
        else if (orientation == "pos1" || orientation == "pos3")
        {
            isAUsed = false;
            isBUsed = true;
            isCUsed = false;
            isDUsed = true;
        }
    }
}
