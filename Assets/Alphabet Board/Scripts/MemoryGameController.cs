﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryGameController : MonoBehaviour
{
	[SerializeField]
	private Sprite bgImage;


	public List<Button> btns = new List<Button>();

    void Start()
    {
		GetButtons();
		AddListeners();
    }

	void GetButtons()
	{
		GameObject[] objects = GameObject.FindGameObjectsWithTag("MemoryButton");

		for (int i = 0; i < objects.Length; i++){
			btns.Add(objects[i].GetComponent<Button>());
			//btn[i].image.sprite = bgImage;
		}
	}
	void AddListeners()
	{
		foreach(Button btn in btns)
		{
			//btn.onClick.AddListener(() => PickAPuzzle);
		}
	}
	public void PickAPuzzle()
	{
		Debug.Log("Click");

	}
}
