using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCtrl : MonoBehaviour 
{
    // Rad Load
    public float radLoadMax;
    public float radLoadValue;

    void Start ()
    {
        radLoadValue = radLoadMax;
    }

    void Update ()
    {
        radLoadValue -= Time.deltaTime;
    }
}
