using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDCtrl : MonoBehaviour {

	GameManager gm;

	void Awake ()
	{
		gm = GameObject.Find("Master Manager").GetComponent<GameManager>();
	}
	void Start () 
	{
		
	}
	
	void Update () 
	{		
		if (Input.anyKeyDown && gm.overlay.transform.GetChild(0).gameObject.activeSelf) // start
		{
			gm.GameStart();
		}

        if (Input.anyKeyDown && gm.overlay.transform.GetChild(1).gameObject.activeSelf) // win
        {
			gm.GameReload();
        }
    }
}
