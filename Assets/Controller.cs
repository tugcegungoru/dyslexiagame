using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

	public void onMatematik()
	{
		Debug.Log("msht");
		Application.LoadLevel("MenuGame");
	}

	public void onHafıza()
	{
		Application.LoadLevel("MemoryGame");
	}

	public void onYapboz()
	{
		Application.LoadLevel("PuzzlesGame");
	}

	public void onKelime()
	{
		Application.LoadLevel("WordGame");
	}

	public void onSettings()
	{
		Application.LoadLevel("Setting");
	}

	public void onHighScoreTable()
	{
		Application.LoadLevel("ScoreTable");
	}

	public void onAlfabe()
	{
		Application.LoadLevel("AlphabetMenu");
	}
}
