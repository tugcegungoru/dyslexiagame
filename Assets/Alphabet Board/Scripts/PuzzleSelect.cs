using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleSelect : MonoBehaviour
{
	public GameObject StartPanel;
	public void SetPuzzlePhoto(Image Photo)
	{
		for(int i=0; i<16; i++)
		{
			GameObject.Find("Piece (" + i + ")").transform.Find("puzzle").GetComponent<SpriteRenderer>().sprite = Photo.sprite;
		}

		StartPanel.SetActive(false);
	}

	public void onMenu()
	{
		Application.LoadLevel("MainMenu");
	}
}
