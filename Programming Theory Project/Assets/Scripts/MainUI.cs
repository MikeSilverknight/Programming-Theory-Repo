using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    [SerializeField] // ENCAPSULATION
    private InfoPopup InfoPopup;
    [SerializeField] // ENCAPSULATION
    private UserControl UserControl;
    
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
            StartCoroutine(DisplayInfo());
        }
    }
    
    IEnumerator DisplayInfo()
    {    
        yield return new WaitForSeconds(0.1f);
        InfoPopup.gameObject.SetActive(true);
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
