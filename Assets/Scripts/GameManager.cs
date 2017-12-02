using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

    // Rad Load
	public Text radLoadText;
    public float radLoadMax;
	public float radLoadValue;
	
	void Start () 
	{
		radLoadValue = radLoadMax;
		radLoadText.text = radLoadValue.ToString();
	}
	
	void Update () 
	{
		radLoadValue -= Time.deltaTime;
		radLoadText.text = Mathf.FloorToInt(radLoadValue).ToString();
	}

	void GameTimer ()
	{

	}
}
