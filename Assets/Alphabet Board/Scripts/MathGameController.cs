using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MathGameController : MonoBehaviour
{

	public Text mathText;
	public Text resultText;
	public Text scoreText;
	public GameObject timeProgress;
	private float limitTime;
	private float currentTime;

	private int leftNumber;
	private int rightNumber;
	private int mathOperator; //( + - * /)
	private int trueResult;
	private int falseResult;
	private int currentScore;
	
	
	private islemcontroller deger;
	public GameObject degerGetir;

	public void Start()
	{
		limitTime = 14.0f;
		currentTime = 0.0f;

		currentScore = 0;
		createMath();
	}

	public void Update()
	{
		currentTime += Time.deltaTime;
		if(currentTime > limitTime)
		{
			LoseGame();
		}
		else
		{
			float scaleProgressTime = 1.0f - currentTime / limitTime;
			timeProgress.transform.localScale = new Vector3(scaleProgressTime, 1, 1);
		}
	}

	public void createMath()
	{
		leftNumber = Random.Range(0, 10);
		rightNumber = Random.Range(0, 10);

		mathOperator = Random.Range(0, 3);

		switch (mathOperator)
		{
			case 0: //+
				trueResult = leftNumber + rightNumber;
				falseResult = trueResult + Random.Range(-2, 4);
				mathText.GetComponent<Text>().text = leftNumber.ToString() + " + " + rightNumber.ToString();
				resultText.GetComponent<Text>().text = falseResult.ToString();
				break;
			case 1: //-
				trueResult = leftNumber - rightNumber;
				falseResult = trueResult + Random.Range(-2, 4);
				mathText.GetComponent<Text>().text = leftNumber.ToString() + " - " + rightNumber.ToString();
				resultText.GetComponent<Text>().text = falseResult.ToString();
				break;
			case 2: //*
				trueResult = leftNumber * rightNumber;
				falseResult = trueResult + Random.Range(-2, 4);
				mathText.GetComponent<Text>().text = leftNumber.ToString() + " * " + rightNumber.ToString();
				resultText.GetComponent<Text>().text = falseResult.ToString();
				break;
			case 3: ///
				trueResult = leftNumber / rightNumber;
				falseResult = trueResult + Random.Range(-2, 4);
				mathText.GetComponent<Text>().text = leftNumber.ToString() + " / " + rightNumber.ToString();
				resultText.GetComponent<Text>().text = falseResult.ToString();
				break;
			default:
				break;
		}

		scoreText.GetComponent<Text>().text = currentScore.ToString();
	}

	public void LoseGame()
	{
		GameValues.currentScore = currentScore;
		int highScore = PlayerPrefs.GetInt("HIGH_SCORE", 0);
		if(currentScore > highScore)
		{
			PlayerPrefs.SetInt("HIGH_SCORE", currentScore);
		}
		Application.LoadLevel("LoseScene");
	}

    public void onTrueButtonClick()
	{
		if(trueResult == falseResult)
		{
			currentTime = 0; 
			currentScore++;
			createMath();
		}
		else
		{
			LoseGame();
		}
	}

	public void onFalseButtonClick()
	{
		if (trueResult != falseResult)
		{
			currentTime = 0;
			currentScore++;
			createMath();
		}
		else
		{
			LoseGame();
		}
	}
}
