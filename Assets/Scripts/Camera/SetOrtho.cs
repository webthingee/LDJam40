using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetOrtho : MonoBehaviour {

	public float screenHeight;
	public float spriteBaseSize;
	public float orthoSize;

	void Awake () 
	{
		if (screenHeight != Screen.height)
		{
			Debug.LogWarning(
				"SetOrtho Script screen height difference setting to " 
				+ Screen.height.ToString() 
				+ " please update when game is not in play");
		}
		screenHeight = Screen.height;
	}
	
	void Start ()
	{
		orthoSize = screenHeight / spriteBaseSize / 2f;
	}
}
