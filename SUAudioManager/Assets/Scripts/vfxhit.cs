﻿using UnityEngine;
using System.Collections;

public class vfxhit : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	public void onGotHit()
	{
		particleSystem.Stop();
		particleSystem.Play();
	}
}
