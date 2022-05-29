using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] squares; // ENCAPSULATION
    GameObject selected1;
    GameObject selected2;
    public GameObject partPrefab1;
    public GameObject partPrefab2;
    public GameObject startPrefab;
    public GameObject endPrefab;
    [SerializeField] public Vector3 startPos {get; private set;} // ENCAPSULATION
    [SerializeField] public int startIndex {get; private set;} // ENCAPSULATION
    [SerializeField] public Vector3 endPos {get; private set;} // ENCAPSULATION
    [SerializeField] public int endIndex {get; private set;} // ENCAPSULATION
    int index;
    
    
    // Start is called before the first frame update
    void Start()
    { 
        StartPart();
        EndPart();
        
        index = Random.Range(0, squares.Length);
        selected1 = squares[index];
        
        index = Random.Range(0, squares.Length);
        selected2 = squares[index];
        
        if (selected1 == selected2)
        {
            RerollSquare2();
        }
        
        InstantiateParts();
    }

    void RerollSquare2()
    {  
        while (selected1 == selected2)
        {
            index = Random.Range(0, squares.Length);
            selected2 = squares[index];
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InstantiateParts()
    {
        Instantiate(partPrefab1, selected1.transform.position, partPrefab1.transform.rotation);
        Instantiate(partPrefab2, selected2.transform.position, partPrefab2.transform.rotation);
    }

    void StartPart()
    {
        var start1 = new Vector3(-4,0,2);
        var start2 = new Vector3(-4,0,0);
        var start3 = new Vector3(-4,0,-2);
        
        Vector3[] startPositions;
        startPositions = new Vector3[]{start1,start2,start3};

        startIndex = Random.Range(0, startPositions.Length);
        startPos = startPositions[startIndex];

        Instantiate(startPrefab, startPos, startPrefab.transform.rotation);
    }

    void EndPart()
    {
        var end1 = new Vector3(4,0,2);
        var end2 = new Vector3(4,0,0);
        var end3 = new Vector3(4,0,-2);

        Vector3[] endPositions;
        endPositions = new Vector3[]{end1,end2,end3};
        
        

        endIndex = Random.Range(0, endPositions.Length);
        endPos = endPositions[endIndex];

        Instantiate(endPrefab, endPos, endPrefab.transform.rotation);
    }
}
