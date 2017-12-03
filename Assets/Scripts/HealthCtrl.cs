using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthCtrl : MonoBehaviour 
{
    // Rad Load
    [SerializeField] float radLoadMax = 100;
    [SerializeField] float radSpeedMax = 5;
    [SerializeField] float radSpeedMin = 1;
    [SerializeField] float radSpeed = 1;
    [SerializeField] float radLoadValue = 0;
    public bool isMainCharacter;
    public bool takingRads = true;
    public Transform radBarLevel;
    public GameObject radBarLevelOverlay;

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

    void Start()
    {
        radBarLevel.transform.parent.gameObject.SetActive(true);
        
        if (!isMainCharacter)
        {
            takingRads = false;

            if (radBarLevelOverlay != null) 
            {
                radBarLevelOverlay.SetActive(true);
            }
        }
    }

    public void AddRads(float _value)
    {
        radLoadValue += _value;
        if (radLoadValue < 0)
        {
            radLoadValue = 0;
        }
        
        if (_value > 0)
        {
            StartCoroutine(radAddDamage());
        }
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
        if (radSpeed > 1)
        {
            StartCoroutine(radSpeedDamage()); 
        }
    }

    void Update ()
    {
        if (takingRads)
        {
            if (radBarLevelOverlay != null)
            { 
                radBarLevelOverlay.SetActive(false);
            }
            radLoadValue += Time.deltaTime * radSpeed;
            float radPercent = ((float)Mathf.FloorToInt(radLoadValue) / 100); // max then * 10? to get %
            radBarLevel.GetComponent<Image>().fillAmount = radPercent;
        }

        if (radLoadValue >= radLoadMax)
        {
            if (isMainCharacter)
            {
                GameObject.Find("Master Manager").GetComponent<GameManager>().ScreenDead();
            }
            else
            {
                if (radBarLevelOverlay != null)
                {
                    radBarLevelOverlay.SetActive(true);
                }
                Destroy(this.gameObject);
            }
        }
    }

    IEnumerator radAddDamage ()
    {
        radBarLevel.GetComponent<Image>().color = Color.red;
        yield return new WaitForSeconds(0.20f);
        radBarLevel.GetComponent<Image>().color = Color.green;
    }

    IEnumerator radSpeedDamage()
    {
        radBarLevel.GetComponent<Image>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        if (radSpeed > 1) {
            StartCoroutine(radSpeedDamage());
        }
        else
        {
            radBarLevel.GetComponent<Image>().color = Color.green;
        }
    }
}
