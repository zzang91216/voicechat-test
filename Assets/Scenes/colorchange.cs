using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class colorchange : MonoBehaviour
{
    private Image img;
    public Color col;
    private Color tempcol;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        tempcol = img.color;
        tempcol = tempcol + (col - tempcol)*speed;
        img.color = tempcol;
    }
}
