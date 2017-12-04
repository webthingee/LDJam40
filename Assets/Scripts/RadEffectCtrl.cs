using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadEffectCtrl : MonoBehaviour 
{
	public int radChange = -10;
	public bool isConsumable;
    public bool canDrainRads;
    public bool isCloud;
    public bool isSludge;

    HealthCtrl hc;
	AudioSource sound;

    void Start()
	{
		hc = GameObject.Find("Player").GetComponent<HealthCtrl>();
		if (GetComponent<AudioSource>() != null)
		{
			sound = GetComponent<AudioSource>();
		}
    }

	void OnTriggerEnter2D(Collider2D other)
	{
        if (GetComponent<AudioSource>() != null)
        {
            sound.Play();
        }
        
		if (canDrainRads)
        {
            DrainRads(radChange);
        }
		else
		{   
			AddRads(radChange);
		}

		if (isConsumable)
		{
			GetComponent<SpriteRenderer>().enabled = false;
			StartCoroutine(ByeBye());
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		hc.RadsSpeed(1);
	}

	void AddRads (int _value)
	{
		GameObject.Find("Player").GetComponent<HealthCtrl>().AddRads(_value);
	}

    void DrainRads(int _value)
    {
        GameObject.Find("Player").GetComponent<HealthCtrl>().RadsSpeed(_value);
    }

	IEnumerator ByeBye ()
	{
		yield return new WaitForSeconds(2f);
		Destroy(this.gameObject);
	}		
}
