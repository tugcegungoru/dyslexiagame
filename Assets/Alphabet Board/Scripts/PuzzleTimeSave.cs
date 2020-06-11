using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PuzzleTimeSave : MonoBehaviour
{
	public Text timeText;
	public Text highTimeText;

	public void Start()
	{
		timeText.GetComponent<Text>().text = "ZAMAN: " + GameValues.currentScore.ToString();
		highTimeText.GetComponent<Text>().text = "REKOR ZAMAN " + PlayerPrefs.GetFloat("REKOR_ZAMAN", 0).ToString();
	}

	public void onPlayAgainButtonClick()
	{
		Application.LoadLevel("PuzzleGame");
	}

	public void onMenuButtonClick()
	{
		Application.LoadLevel("MenuGame");
	}
}
