using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    public InfoPopup InfoPopup;
    public UserControl UserControl;
    
    private void Awake()
    {
        InfoPopup.gameObject.SetActive(false);
    }

    public void SetInfo()
    {
        var selected = UserControl.partSelected;
        
        if (UserControl.partSelected == null)
        {
            InfoPopup.gameObject.SetActive(false);
        }
        else
        {
            InfoPopup.Name.text = selected.GetPartName();
            InfoPopup.Catagory.text = selected.GetCategory();
            InfoPopup.gameObject.SetActive(true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetInfo(); // ABSTRACTION
        }
    }
}
