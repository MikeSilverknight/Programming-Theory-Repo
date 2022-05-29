using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Master subclass for piping components.
/// </summary>
public abstract class PipePart : ComponentPart // INHERITANCE
{
    public override string GetCategory() // POLYMORPHISM
    {
        return "Pipe";
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

    
}
