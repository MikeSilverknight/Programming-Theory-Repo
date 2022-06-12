using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserControl : MonoBehaviour
{
    [SerializeField] private Camera gameCamera; // ENCAPSULATION
    public PipePart partSelected {get; private set;} // ENCAPSULATION
    public PartMarker markerIcon;

    // Start is called before the first frame update
    void Start()
    {
        markerIcon.gameObject.SetActive(false);
        partSelected = null;
    }
    
    void HandleSelection()
    {
        var ray = gameCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var part = hit.collider.GetComponentInParent<PipePart>();
            var placement = hit.collider.GetComponentInParent<GridSquare>();
            var spawner = hit.collider.GetComponentInParent<SpawnSquare>();
            
            //determine if we clicked on a part or a placement spot or otherwise
            //if you click on a movable part, select it
            if (part != null) 
            {
                partSelected = part;
                part.GetPartName();
                part.RotationDetector();
                markerIcon.TeleportToSelected();
                markerIcon.gameObject.SetActive(true);
            }
            //if you click on non-spawner square with a part selected, place the part
            else if (placement != null && partSelected != null && !placement.isOccupied && !placement == spawner) 
            { 
                partSelected.transform.position = placement.transform.position;
                
                part = null;
                placement = null;
                partSelected = null;
                markerIcon.gameObject.SetActive(false);            
            }
            //if you click on an empty spawner, spawn new part
            else if (spawner && partSelected == null && !placement.isOccupied)
            {
                spawner.InstantiatePart();
            }
            //if you click on nothing, deselect
            else
            {
                part = null;
                placement = null;
                partSelected = null;
                markerIcon.gameObject.SetActive(false);
            }
        }
    }

    void HandleRotation()
    {
        if (partSelected != null)
            { 
                partSelected.transform.Rotate(0,90,0);
                partSelected.Orientate();
                partSelected.RotationDetector();        
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