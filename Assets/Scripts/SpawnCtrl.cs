using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCtrl : MonoBehaviour {

	public GameObject prefab;
	public float timeBetween;
	public Transform dropSpot;
	
	void Start () 
	{
		StartCoroutine(SpawnPrefab(timeBetween));
	}

	IEnumerator SpawnPrefab (float _value)
	{
        yield return new WaitForSeconds(_value);
        Instantiate(prefab, dropSpot.position, dropSpot.rotation);
		StartCoroutine(SpawnPrefab(_value));
	}
}
