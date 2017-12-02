using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadEffectCtrl : MonoBehaviour 
{
	public int radChange = -10;
	public bool isConsumable;
	public bool canDrainRads;

	HealthCtrl hc;

	void Start()
	{
		hc = GameObject.Find("Player").GetComponent<HealthCtrl>();
    }

	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log(other.name + " hits " + this.name);
	
        if (canDrainRads)
        {
            DrainRads(5);
        }
		else
		{
			AddRads(radChange);
		}

		if (isConsumable)
		{
			Destroy(this.gameObject);
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		hc.RadsSpeed(0);
	}

	void AddRads (int _value)
	{
		GameObject.Find("Player").GetComponent<HealthCtrl>().AddRads(_value);
	}

    void DrainRads(int _value)
    {
        GameObject.Find("Player").GetComponent<HealthCtrl>().RadsSpeed(_value);
    }	
	
}
