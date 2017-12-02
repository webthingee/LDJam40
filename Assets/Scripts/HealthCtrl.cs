using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCtrl : MonoBehaviour 
{
    // Rad Load
    public float radLoadMax;
    public float radSpeed = 1;
    [SerializeField] float radLoadValue = 0;

    public float RadLoadValue {
        get { return radLoadValue; }
        set { radLoadValue += value; }
    }
    
    public void AddRads (float _value) {
        radLoadValue += _value;
        if (radLoadValue < 0) { 
            radLoadValue = 0;
        } 
    }

    void Start ()
    {
    }

    void Update ()
    {
        radLoadValue += Time.deltaTime * radSpeed;
        if (radLoadValue >= radLoadMax)
        {
            Debug.Log("DEAD");
            GameObject.Find("Master Manager").GetComponent<GameManager>().GameReload();
        }
    }
}
