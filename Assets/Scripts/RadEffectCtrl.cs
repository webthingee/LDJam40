using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadEffectCtrl : MonoBehaviour {

	void Start()
	{

    }

	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log(other.name);
		GameObject.Find("Player").GetComponent<HealthCtrl>().radLoadValue += 10;
	}
	
}
