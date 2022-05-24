using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Master class for machine components.
/// </summary>
public abstract class ComponentPart : MonoBehaviour
{
    public string orientation;
    
    // Start is called before the first frame update
    
    void Awake()
    {    
        orientation = "pos0";
    }
    
    void Start()
    {
        
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

    public virtual string GetPartName()
    {
        return "Part";
    }
    public abstract string GetCategory();
    public abstract void RotationDetector();
}
