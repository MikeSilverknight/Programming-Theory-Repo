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
    
    public float directionFaced {get; private set;} // ENCAPSULATION
    
    void Start()
    {
        RotationDetector(); // ABSTRACTION
    }

    void Update()
    {
        
    }

    public override void RotationDetector()
    {
        directionFaced = this.transform.rotation.y;
        
        if (directionFaced == 90)
        {
            isAUsed = true;
            isBUsed = true;
            isCUsed = false;
            isDUsed = false;
        }
        else if (directionFaced == 180)
        {
            isAUsed = false;
            isBUsed = true;
            isCUsed = true;
            isDUsed = false;
        }
        else if (directionFaced == -90)
        {
            isAUsed = false;
            isBUsed = false;
            isCUsed = true;
            isDUsed = true;
        }
        else if (directionFaced == 0)
        {
            isAUsed = true;
            isBUsed = false;
            isCUsed = false;
            isDUsed = true;
        }    
    }
}
