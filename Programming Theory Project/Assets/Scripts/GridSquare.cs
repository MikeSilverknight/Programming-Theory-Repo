using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSquare : MonoBehaviour
{
    public bool isOccupied {get; private set;} // ENCAPSULATION
    public GameObject occupyingPart {get; private set;} // ENCAPSULATION
    
    protected virtual void OnTriggerEnter(Collider other) // POLYMORPHISM
    {
        isOccupied = true;
        occupyingPart = other.gameObject;
        occupyingPart.GetComponent<PipePart>().currentSquare = this.gameObject;
    }
    protected void OnTriggerExit(Collider other)
    {
        isOccupied = false;
        occupyingPart = null;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        isOccupied = false;
        occupyingPart = null;  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}