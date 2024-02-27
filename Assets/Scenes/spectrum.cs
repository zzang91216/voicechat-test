using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Voice.PUN;
using Photon.Voice.Unity;

public class spectrum : MonoBehaviour
{
    private AudioClip audioc;
    public AudioSource audios;
    public float[] samples = new float[64];
    // Start is called before the first frame update
    void Start()
    {
        
        audios = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioc = GameObject.Find("Recorder").GetComponent<Recorder>().AudioClip;
        audios.clip = audioc;
        audios.Play();
        audios.GetSpectrumData(samples, 0, FFTWindow.Rectangular);
        Debug.Log(audioc);
    }
}
