using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

    // Rad Load
	public Text radLoadText;	
	private float radLoadValue;
	
	public GameObject player;
	
	void Update () 
	{
		radLoadValue = player.GetComponent<HealthCtrl>().RadLoadValue;
		radLoadText.text = Mathf.FloorToInt(radLoadValue).ToString();
	}

}
