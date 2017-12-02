using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCtrl : MonoBehaviour 
{
    // Rad Load
    [SerializeField] float radLoadMax;
    [SerializeField] float radSpeedMax = 5;
    [SerializeField] float radSpeedMin = 1;
    [SerializeField] float radSpeed = 1;
    [SerializeField] float radLoadValue = 0;
    public bool isMainCharacter;

    GameManager gm;

    public float RadLoadValueMax {
        get { return radLoadMax; }
        set { radLoadMax = value; }
    }
    public float RadLoadValue {
        get { return radLoadValue; }
        set { radLoadValue = value; }
    }
    public float RadSpeedValue {
        get { return radSpeed; }
        set { radSpeed = value; }
    }

    public void AddRads (float _value) {
        radLoadValue += _value;
        if (radLoadValue < 0) { 
            radLoadValue = 0;
        }
        GameObject.Find("Master Manager").GetComponent<GameManager>().tookHit = true;
    }

    public void RadsSpeed(float _value)
    {
        radSpeed = _value;
        if (radSpeed < radSpeedMin)
        {
            radSpeed = radSpeedMin;
        }
        if (radSpeed > radSpeedMax)
        {
            radSpeed = radSpeedMax;
        }
        GameObject.Find("Master Manager").GetComponent<GameManager>().tookHit = true;
    }

    void Start ()
    {
    }

    void Update ()
    {
        radLoadValue += Time.deltaTime * radSpeed;
        if (radLoadValue >= radLoadMax)
        {
            if (isMainCharacter)
            {
                Debug.Log("DEAD");
                GameObject.Find("Master Manager").GetComponent<GameManager>().GameReload();
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}
