using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class global : MonoBehaviour
{
    private GameObject[] spawns;
    public static GameObject canvas;
    public GameObject canvastemp;
    // Start is called before the first frame update
    void Start()
    {
        canvas = canvastemp;
        Application.targetFrameRate = 80;
    }

    // Update is called once per frame
    void Update()
    {
        
        spawns = GameObject.FindGameObjectsWithTag("square");
        for(int i = 0; i < spawns.Length; i++){
            spawns[i].GetComponent<squaress>().order = i;
        }
    }
}
