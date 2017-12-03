using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDCtrl : MonoBehaviour {

	GameManager gm;

	void Awake ()
	{
		gm = GameObject.Find("Master Manager").GetComponent<GameManager>();
	}
	
	void Update () // after the screen is presented.
	{		
		if (Input.anyKeyDown && gm.overlay.transform.GetChild(0).gameObject.activeSelf) // start
		{
			gm.GameInitialize();
		}

        if (Input.anyKeyDown && gm.overlay.transform.GetChild(1).gameObject.activeSelf) // win
        {
			gm.GameReload();
        }
        if (Input.anyKeyDown && gm.overlay.transform.GetChild(2).gameObject.activeSelf) // dean
        {
            gm.GameReload();
        }
    }
}
