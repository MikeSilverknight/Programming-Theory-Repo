using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeConnectivity : MonoBehaviour
{
    private PipePart pipe;
    public string orientation;
    
    // Start is called before the first frame update
    void Awake()
    {
        pipe = gameObject.GetComponent<PipePart>();
        orientation = pipe.orientation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // This feels like the coding equivalant of a rat's nest of wires, I need to learn how to do this easier
    public void LookForConnections()
    {
        orientation = pipe.orientation;
        
        if (pipe = gameObject.GetComponent<Pipe_L>())
        {
            if (orientation == "pos0")
            {
                CheckUp();
                CheckLeft();
            }
            else if (orientation == "pos1")
            {
                CheckUp();
                CheckRight();
            }  
            else if (orientation == "pos2")
            {
                CheckRight();
                CheckDown();
            }
            else if (orientation == "pos3")
            {
                CheckDown();
                CheckLeft();
            }   
        }
        if (pipe = gameObject.GetComponent<Pipe_I>())
        {
            if (orientation == "pos0" || orientation == "pos2")
            {
                CheckUp();
                CheckDown();
            }
            else if (orientation == "pos1" || orientation == "pos3")
            {
                CheckRight();
                CheckLeft();
            }
        }   
    }

    void CheckUp()
    {
        
    }

    void CheckRight()
    {
        
    }

    void CheckDown()
    {

    }

    void CheckLeft()
    {
        
    }
}
