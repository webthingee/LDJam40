using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RescueAction : MonoBehaviour {

    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        GameObject.Find("Player").GetComponent<MissionCtrl>().AddRescue(1);
        Destroy(this.gameObject);
    }
}
