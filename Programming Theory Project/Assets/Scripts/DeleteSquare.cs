using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteSquare : GridSquare
{
    [SerializeField] private UserControl userControl; // ENCAPSULATION
    [SerializeField] private SpawnerPopup spawnerPopup; // ENCAPSULATION
    
    public string displayText;
   
    //If your mouse hovers over the GameObject with the script attached
    void OnMouseOver()
    {
        if (userControl.partSelected == null && !isOccupied)
        {
            DeleteInfo();
        }
    }
    protected override void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject, 0.2f);
    }

    void OnMouseExit()
    {
        spawnerPopup.gameObject.SetActive(false);
    }

    void DeleteInfo()
    {   
        spawnerPopup.gameObject.SetActive(true);
        spawnerPopup.spawnerUI.text = displayText;
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
