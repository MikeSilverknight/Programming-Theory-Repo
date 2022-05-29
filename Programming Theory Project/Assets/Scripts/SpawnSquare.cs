using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSquare : GridSquare // INHERITANCE
{
    [SerializeField] private UserControl userControl; // ENCAPSULATION
    [SerializeField] private SpawnerPopup spawnerPopup; // ENCAPSULATION
    public string displayText;
    public GameObject partPrefab;
   
    //If your mouse hovers over the GameObject with the script attached
    void OnMouseOver()
    {
        if (userControl.partSelected == null && !isOccupied)
        {
            HelperInfo();
        }
    }

    void OnMouseExit()
    {
        spawnerPopup.gameObject.SetActive(false);
    }

    public void HelperInfo()
    {   
        spawnerPopup.gameObject.SetActive(true);
        spawnerPopup.spawnerUI.text = displayText;
    }

    public void InstantiatePart()
    {
        Instantiate(partPrefab, transform.position, partPrefab.transform.rotation);
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
