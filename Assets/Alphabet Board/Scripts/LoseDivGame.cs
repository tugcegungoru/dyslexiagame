using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoseDivGame : MonoBehaviour
{
	public Text currentScoreText;
	public Text highScoreText;

	public void Start()
	{
		currentScoreText.GetComponent<Text>().text = "PUAN " + GameValues.currentScore.ToString();
		highScoreText.GetComponent<Text>().text = "EN YÜKSEK PUAN " + PlayerPrefs.GetInt("HIGH_SCORE", 0).ToString();
	}

	public void onPlayAgainButtonClick()
	{
		Application.LoadLevel("MathDiv");
	}

	public void onMenuButtonClick()
	{
		Application.LoadLevel("MathMenuGame");
	}
}
