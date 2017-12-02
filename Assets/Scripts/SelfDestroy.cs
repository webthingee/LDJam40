using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour {

    public float lifespan;

	void Start()
    {
        StartCoroutine(SpawnDestroy(lifespan));
    }

    IEnumerator SpawnDestroy(float _value)
    {
        yield return new WaitForSeconds(_value);
        Destroy(this.gameObject);
    }
}
