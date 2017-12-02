using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {

    // Rad Value
    public Text radValueText;
    private float radValue;    
	
	// Rad Value 1
    public Text radValueText1;
    private float radValue1;

    // Rad Value 2
    public Text radValueText2;
    private float radValue2;

    // Rad Value 3
    public Text radValueText3;
    private float radValue3;

    // Rescue Value 4
    public Text rescueValueText;
    private float rescueValue;

	public bool didWin;
	public bool tookHit;

	public GameObject player;
	public GameObject startBtn;
	public GameObject overlay;
	
	void Awake ()
	{

    }

	void Start ()
	{
		overlay.SetActive(false);
        overlay.transform.GetChild(0).gameObject.SetActive(false);
        overlay.transform.GetChild(1).gameObject.SetActive(false);

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
		
		if (tookHit || player.GetComponent<HealthCtrl>().RadSpeedValue > 1)
		{
            StartCoroutine(TookHitCooldown());
			tookHit = false;
		}
		else
        {
            radValueText.color = Color.black;
        }
    }

	IEnumerator TookHitCooldown ()
	{
        radValueText.color = Color.red;
		yield return new WaitForSeconds(1f);
	}

    void UpdateRescueValues()
    {
        rescueValue = player.GetComponent<MissionCtrl>().RescueValue;
        rescueValueText.text = Mathf.FloorToInt(rescueValue).ToString() + " / " + player.GetComponent<MissionCtrl>().RescueValueMax;
    }

	public void GameStop () 
	{
		overlay.SetActive(true);
        overlay.transform.GetChild(0).gameObject.SetActive(true); // start
        
		Time.timeScale = 0;
	}

	public void GameStart () 
	{
		Time.timeScale = 1;
		
		overlay.SetActive(false);
        overlay.transform.GetChild(1).gameObject.SetActive(false);
        overlay.transform.GetChild(0).gameObject.SetActive(false);

        player.GetComponent<MissionCtrl>().RescueValue = 0;
	}
	
	public void GameWin ()
	{
		overlay.SetActive(true);
		overlay.transform.GetChild(1).gameObject.SetActive(true); // win
		
		Time.timeScale = 0f;
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
