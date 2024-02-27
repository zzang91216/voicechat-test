using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class instantiate : MonoBehaviour
{
    public GameObject prefeb;
    private GameObject canvas;
    private GameObject child;
    private bool yes = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(canvas == null){
            canvas = GameObject.Find("canvas");
        }
        if(yes == false){
            child = Instantiate(prefeb, prefeb.transform.position, prefeb.transform.rotation);
            child.transform.SetParent(canvas.transform,false);
            child.GetComponent<squaress>().par = gameObject;
            Debug.Log(child.GetComponent<squaress>().par);
            yes = true;
        }
        if(child == null){
            yes = false;
        }
    }
}
