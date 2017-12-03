using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionCtrl : MonoBehaviour 
{
    // Rescue Value
    [SerializeField] int rescueValueMax = 0;
    [SerializeField] int rescueValue;
    [SerializeField] List<HealthCtrl> Ants = new List<HealthCtrl>();

    public int RescueValueMax
    {
        get { return rescueValueMax; }
        set { rescueValueMax = value; }
    }

    public int RescueValue
    {
        get { return rescueValue; }
        set { rescueValue = value; }
    }
    public void AddRescue (int _value)
    {
        rescueValue += _value;
        RescueValueCheck();
    }

    void Start()
    {
        rescueValueMax = 0;
        GameObject gOAnts = GameObject.Find("Ants");
        int i = 0;
        while (i < gOAnts.transform.childCount)
        {
            if (gOAnts.transform.GetChild(i).gameObject.activeSelf)
            {
                rescueValueMax++;
            }
            i++;
        }
    }

    void RescueValueCheck ()
    {
        if (rescueValue >= rescueValueMax)
        {
            Debug.Log("Rescue Value WIN");
			GameObject.Find("Master Manager").GetComponent<GameManager>().ScreenWin();        
		}
		else
		{
			Debug.Log("More to rescue!");
		}
    }
}
