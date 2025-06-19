using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleZfromZero : MonoBehaviour
{
	private float sc;
	private float startSc;
	private int step;

	public float scale;
	public float zoomSpeed;
	public float startSpeed;

	private float speed;

	private int trig;

	// Use this for initialization
	void Start ()
	{
		sc = transform.localScale.x;
		startSc = sc;

		speed = startSpeed;

		if (speed == 0) speed = 0.3f;
		if (scale == 0) scale = 1.2f;

		step = 1;
		sc = 0.01f;
		transform.localScale = Vector3.zero;
	}

	// Update is called once per frame
	void Update () {

		if (step == 0)
		{
			sc += Time.deltaTime * speed;
			transform.localScale = new Vector3(sc,sc,1);

			if (sc > startSc * scale){
				step = 1;
			}
		}
		else
		{
			sc -= Time.deltaTime * speed;
			transform.localScale = new Vector3(sc,sc,1);

			if (sc < startSc){
				step = 0;
				trig++;
				if (trig >1) speed = zoomSpeed;
			}
		}

	}
}
