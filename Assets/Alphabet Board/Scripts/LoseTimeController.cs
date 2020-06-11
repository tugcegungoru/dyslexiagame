using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseTimeController : MonoBehaviour
{
	public Text second;
	public Text minute;
	public Text currentScoreText;
	public void Start()
	{
		minute.GetComponent<Text>().text = "BİTİRME SÜRESİ " + PlayerPrefs.GetFloat("minute", 0).ToString() + " : " + PlayerPrefs.GetFloat("second", 0).ToString();

	}

	public void onPlayAgainButtonClick()
	{
		Application.LoadLevel("MemoryGame");
	}

	public void onMenuButtonClick()
	{
		Application.LoadLevel("MainMenu");
	}
}
