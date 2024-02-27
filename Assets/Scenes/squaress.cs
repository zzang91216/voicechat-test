using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class squaress : MonoBehaviourPunCallbacks
{
	public GameObject par;
	private int num;
	public int order;
	private int gain;
	private int xx;
	private int yy;

	private float xmin;
	private float xmax;
	private float ymin;
	private float ymax;

	private float wid;
	private float hei;
	private RectTransform rectt;
	private Vector3 tempvec;
	private int yymax;
    // Start is called before the first frame update
    void Start () {
		rectt = GetComponent<RectTransform>();
		wid = GameObject.Find("canvas").GetComponent<RectTransform>().rect.width;
		hei = GameObject.Find("canvas").GetComponent<RectTransform>().rect.height;
		if(transform.parent == null){
			transform.SetParent(GameObject.Find("canvas").transform,false);
		}
		order = GameObject.FindGameObjectsWithTag("square").Length-1;
		num = GameObject.FindGameObjectsWithTag("square").Length;
		gain = (int)Mathf.Ceil(Mathf.Sqrt((float)num));
		xx = order%gain;
		yy = ((order-xx)/gain);
		yymax = 1 + ((num-1)-(num-1)%gain)/gain;
		xmin = wid/((float)gain) * (float)(xx+1);
		ymin = hei/((float)yymax) * (float)(0);
		xmax = wid/((float)gain) * (float)(xx+1);
		ymax = hei/((float)yymax) * (float)(0);
		
	}
		
	void Update()
	{
		if(par == null){
			Destroy(gameObject);
		}
		num = GameObject.FindGameObjectsWithTag("square").Length;
		gain = (int)Mathf.Ceil(Mathf.Sqrt((float)num));
		xx = order%gain;
		yy = ((order-xx)/gain);
		yymax = 1 + ((num-1)-(num-1)%gain)/gain;

		xmin += (wid/((float)gain) * (float)xx+20f - xmin)/5f;
		ymin += (hei/((float)yymax) * (float)(yymax-yy-1)+20f - ymin)/5f;
		xmax += (wid/((float)gain) * (float)(xx+1)-20f - xmax)/5f;
		ymax += (hei/((float)yymax) * (float)(yymax-yy)-20f - ymax)/5f;

		rectt.offsetMin = new Vector2(xmin, ymin);
		rectt.offsetMax = new Vector2(xmax, ymax);
		
	}
	
}
