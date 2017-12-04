using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RescueAction : MonoBehaviour {

    AudioSource sound;

    void Start ()
    {
        sound = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        sound.Play();
        
        GameObject.Find("Player").GetComponent<MissionCtrl>().AddRescue(1);
        this.GetComponent<HealthCtrl>().takingRads = true;

        transform.position = new Vector2(-9999, -9999);
    }
}
