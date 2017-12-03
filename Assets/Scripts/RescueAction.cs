using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RescueAction : MonoBehaviour {

    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name + " hits " + this.name);

        GameObject.Find("Player").GetComponent<MissionCtrl>().AddRescue(1);
        this.GetComponent<HealthCtrl>().takingRads = true;

        transform.position = new Vector2(-9999, -9999);
    }
}
