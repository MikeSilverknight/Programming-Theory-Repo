using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Master class for machine components.
/// </summary>
public abstract class ComponentPart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual string GetPartName()
    {
        return "Part";
    }
    public abstract string GetCategory();
    public abstract void RotationDetector();
}
