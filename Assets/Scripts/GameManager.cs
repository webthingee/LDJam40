using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {

    // Rad Value
	public Text radValueText;	
	private float radValue;

    // Rescue Value
    public Text rescueValueText;
    private float rescueValue;

	public bool didWin;

	public GameObject player;
	public GameObject startBtn;
	public GameObject overlay;
	
	void Start ()
	{
		overlay.SetActive(false);
		GameStop();
	}

	void Update () 
	{
		UpdateRadValues();
		UpdateRescueValues();
	}

	void UpdateRadValues ()
	{
        radValue = player.GetComponent<HealthCtrl>().RadLoadValue;
        radValueText.text = Mathf.FloorToInt(radValue).ToString() + " / " + player.GetComponent<HealthCtrl>().RadLoadValueMax;
	}

    void UpdateRescueValues()
    {
        rescueValue = player.GetComponent<MissionCtrl>().RescueValue;
        rescueValueText.text = Mathf.FloorToInt(rescueValue).ToString() + " / " + player.GetComponent<MissionCtrl>().RescueValueMax;
    }

	public void GameStop () {
		startBtn.SetActive(true);
		Time.timeScale = 0;
	}

	void GameStart () {
        startBtn.SetActive(false);
		overlay.SetActive(false);

		player.GetComponent<MissionCtrl>().RescueValue = 0;

        Time.timeScale = 1;
	}
	
	public void GameWin ()
	{
		overlay.SetActive(true);
		Time.timeScale = 0.05f;
		Invoke("GameReload", 0.2f);
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
