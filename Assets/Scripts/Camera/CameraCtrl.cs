using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour {

	public GameObject player;
	public Vector3 cameraOffset = new Vector3(5f, 1f, -10f);
	public float horizontalSpeed = 2f;
	public float verticalSpeed = 2f;

	Transform mainCamera;
	//PlayerCtrl playerCtrl;

	void Awake () 
	{
		if (!player)
		{
			player = GameObject.FindGameObjectWithTag("Player");
		}

		//playerCtrl = player.GetComponent<PlayerCtrl>();	
		mainCamera = Camera.main.transform;
		mainCamera.position = new Vector3(
			player.transform.position.x + cameraOffset.x,
			player.transform.position.y + cameraOffset.y,
			player.transform.position.z + cameraOffset.z);
	}
	
	void Start ()
	{

	}

    void Update () 
	{		
		PlayerStatusCheck();

		if (player.transform.eulerAngles.y == 0) {
			mainCamera.position = new Vector3 (
				Mathf.Lerp(mainCamera.position.x, player.transform.position.x - cameraOffset.x, horizontalSpeed * Time.deltaTime),
                Mathf.Lerp(mainCamera.position.y, player.transform.position.y + cameraOffset.y, verticalSpeed * Time.deltaTime),
				cameraOffset.z);
        }
		else
		{
            mainCamera.position = new Vector3(
                Mathf.Lerp(mainCamera.position.x, player.transform.position.x + cameraOffset.x, horizontalSpeed * Time.deltaTime),
                Mathf.Lerp(mainCamera.position.y, player.transform.position.y + cameraOffset.y, verticalSpeed * Time.deltaTime),
                cameraOffset.z);
        }
	}

    void PlayerStatusCheck()
    {
        if (player.transform.position.y <= mainCamera.position.y + -10)
        {
            GameObject.Find("Master Manager").GetComponent<GameManager>().GameReload();
        }
    }
}
