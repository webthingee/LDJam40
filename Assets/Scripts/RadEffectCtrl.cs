using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadEffectCtrl : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D other)
	{
		GameObject.Find("Master Manager").GetComponent<GameManager>().radLoadValue += 99;
		Debug.Log("Master");
	}
	
}
