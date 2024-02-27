using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Voice.PUN;
using Photon.Voice.Unity;

public class speak : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.parent.GetComponent<squaress>().par.transform.GetChild(0).gameObject.GetComponent<Speaker>().IsPlaying){
            gameObject.GetComponent<colorchange>().col = new Color(0.5f,1f,0.5f,1f);
            gameObject.GetComponent<colorchange>().speed = 0.2f;
        }
        else{
            gameObject.GetComponent<colorchange>().col = new Color(0.8f,0.5f,0.5f,0.3f);
            gameObject.GetComponent<colorchange>().speed = 0.05f;
        }
    }
}