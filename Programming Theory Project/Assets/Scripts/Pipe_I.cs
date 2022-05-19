using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sub-subclass for the I-Pipe.
/// </summary>
public class Pipe_I : PipePart // INHERITANCE
{


    public override string GetPartName() // POLYMORPHISM
    {
        return "I-Pipe";
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
        
        if (directionFaced == 90 || directionFaced == -90)
        {
            isAUsed = false;
            isBUsed = true;
            isCUsed = false;
            isDUsed = true;
        }
        else if (directionFaced == 180 || directionFaced == 0)
        {
            isAUsed = true;
            isBUsed = false;
            isCUsed = true;
            isDUsed = false;
        }
    }
}
