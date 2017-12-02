using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionCtrl : MonoBehaviour 
{
    // Rescue Value
    [SerializeField] float rescueValueMax = 3;
    [SerializeField] float rescueValue;

    public float RescueValueMax
    {
        get { return rescueValueMax; }
        set { rescueValueMax = value; }
    }

    public float RescueValue
    {
        get { return rescueValue; }
        set { rescueValue = value; }
    }
    public void AddRescue (float _value)
    {
        rescueValue += _value;
        RescueValueCheck();
    }

    void Start()
    {
		
    }

    void RescueValueCheck ()
    {
        if (rescueValue >= rescueValueMax)
        {
            Debug.Log("Rescue Value WIN");
			GameObject.Find("Master Manager").GetComponent<GameManager>().GameWin();        
		}
		else
		{
			Debug.Log("More to rescue!");
		}
    }
}
