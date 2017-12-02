using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {

    // Rad Load
	public Text radLoadText;	
	private float radLoadValue;
	
	public GameObject player;

	public GameObject startBtn;
	
	void Start ()
	{
		GameStop();
	}

	void Update () 
	{
		UpdateRadLevels();
	}

	void UpdateRadLevels ()
	{
        radLoadValue = player.GetComponent<HealthCtrl>().RadLoadValue;
        radLoadText.text = Mathf.FloorToInt(radLoadValue).ToString() + " / 100";
	}

	public void GameStop () {
		startBtn.SetActive(true);
		Time.timeScale = 0;
	}

	void GameStart () {
        startBtn.SetActive(false);
        Time.timeScale = 1;
	}
	
	public void GameReload ()
	{
		SceneManager.LoadScene("Demo");
	}

    public void ButtonReStart()
    {
        GameStart();
    }
}
