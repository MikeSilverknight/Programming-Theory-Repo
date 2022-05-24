using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSquare : MonoBehaviour
{
    public bool isOccupied = false;
    
    protected virtual void OnTriggerEnter(Collider other)
    {
        isOccupied = true;
    }
    protected void OnTriggerExit(Collider other)
    {
        isOccupied = false;
    }
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
