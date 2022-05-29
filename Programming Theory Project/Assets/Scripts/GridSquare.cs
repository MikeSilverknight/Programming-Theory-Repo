using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSquare : MonoBehaviour
{
    public bool isOccupied = false;
    public GameObject occupyingPart;
    
    protected virtual void OnTriggerEnter(Collider other)
    {
        isOccupied = true;
        occupyingPart = other.gameObject;
    }
    protected void OnTriggerExit(Collider other)
    {
        isOccupied = false;
        occupyingPart = null;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        occupyingPart = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
