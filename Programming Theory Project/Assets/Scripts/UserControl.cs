using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserControl : MonoBehaviour
{
    [SerializeField] // ENCAPSULATION
    private Camera gameCamera;
    
    public ComponentPart partSelected = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void HandleSelection()
    {
        var ray = gameCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var part = hit.collider.GetComponentInParent<ComponentPart>();
            var placement = hit.collider.GetComponentInParent<GridSquare>();
            var target = hit.collider;
            
            //determine if we clicked on a part or a placement spot
            if (part != null)
            {
                partSelected = part;
                part.GetPartName();

            }
            else if (placement != null && partSelected != null && !placement.isOccupied)
            { 
                partSelected.transform.position = placement.transform.position;
                
                PartPlacement();
                
                placement.isOccupied = true;
                part = null;
                placement = null;
                target = null;
            } 
        }
    }

    public void PartPlacement()
    {
        partSelected = null; 
    }

    public void HandleRotation()
    { 
        if (partSelected != null)
            { 
                partSelected.transform.Rotate(0,90,0);
            } 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //left click to pickup and place
        {
            HandleSelection(); // ABSTRACTION
        }

         if (Input.GetMouseButtonDown(1)) //right click to rotate
        {
            HandleRotation(); // ABSTRACTION
        }
    }
}
