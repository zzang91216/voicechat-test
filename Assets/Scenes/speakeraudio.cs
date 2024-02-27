using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Photon.Voice.PUN;
using Photon.Voice.Unity;
using Photon.Pun;

public class speakeraudio : MonoBehaviour
{
    float sum;
    public bool islocal = false;
    private RectTransform[] bars = new RectTransform[64];
    public float[] samples = new float[64];
    public float[] oldsamples = new float[64];
    public int delay;
    private Queue<float[]> datas;
    // Start is called before the first frame update
    void Start()
    {
        datas = new Queue<float[]>();
    }

    // Update is called once per frame
    void Update()
    {
        delay = (int)(80*gameObject.GetComponent<Speaker>().PlayDelay/1000);
        if(transform.parent.GetComponent<PhotonVoiceView>().IsRecording){
            islocal = true; 
        }
        samples = new float[64];
        GetComponent<AudioSource>().GetSpectrumData(samples, 0, FFTWindow.Rectangular);
        datas.Enqueue(samples);
        if(datas.Count>delay){
            for(int i = 0; i < datas.Count-delay; i++){
                oldsamples = datas.Dequeue();
                Debug.Log(oldsamples[0]);
            }
        }
    }
    
    private void OnAudioFilterRead(float[] data, int channels) {
        sum = 0;
        Array.ForEach(data, i => sum += Mathf.Abs(i)/(float)data.Length);
        if(islocal){
            for(int i = 0; i < data.Length; i++){
                data[i] = 0f;
            }
        }
    }
}
