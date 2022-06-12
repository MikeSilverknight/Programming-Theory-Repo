using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    [SerializeField] private InfoPopup infoPopup; // ENCAPSULATION
    [SerializeField] private SpawnerPopup spawnerPopup; // ENCAPSULATION
    [SerializeField] private UserControl userControl; // ENCAPSULATION

    PipeStart start;
    
    private void Awake()
    {
        infoPopup.gameObject.SetActive(false);
        spawnerPopup.gameObject.SetActive(false);
    }

    public void SetInfo()
    {
        var selected = userControl.partSelected;
        
        if (userControl.partSelected == null)
        {
            infoPopup.gameObject.SetActive(false);
        }
        else
        {
            infoPopup.Name.text = selected.GetPartName();
            infoPopup.Catagory.text = selected.GetCategory();
            StartCoroutine(DisplayInfo());
        }
    }
    
    IEnumerator DisplayInfo()
    {    
        yield return new WaitForSeconds(0.1f);
        infoPopup.gameObject.SetActive(true);
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

    public void StartConnection()
    {
        start = GameObject.Find("PipeStart(Clone)").GetComponent<PipeStart>();
        start.FindStartConnection();
    }
}
