using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartMarker : MonoBehaviour
{
    private Vector3 scaleChange;
    private float speed = 3.0f;
    [SerializeField] private UserControl controller;


    // Start is called before the first frame update
    void Start()
    {
        scaleChange = new Vector3(-0.01f, -0.01f, -0.01f) / speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += scaleChange;

        // when the marker scale extends 1.0f.
        if (transform.localScale.y < 0.9f || transform.localScale.y > 1.1f)
        {
            scaleChange = -scaleChange;   
        }
    }

    public void TeleportToSelected()
    {
        var partSelected = controller.partSelected;
        
        if (partSelected != null)
        {
            transform.position = controller.partSelected.transform.position;
        } 
    }
}
