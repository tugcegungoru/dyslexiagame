using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainToken : MonoBehaviour
{
	GameObject gameController;
	SpriteRenderer spriteRenderer;
	public Sprite[] faces;
	public Sprite back;
	public int faceIndex;
	public bool matched = false;

	public void OnMouseDown()
	{
		if (matched == false)
		{
			if (spriteRenderer.sprite == back)
			{
				if (gameController.GetComponent<GameController>().TwoCardsUp() == false)
				{
					spriteRenderer.sprite = faces[faceIndex];
					gameController.GetComponent<GameController>().AddVisibleFace(faceIndex);
					matched = gameController.GetComponent<GameController>().CheckMatch();
				}
			}
			else
			{
				spriteRenderer.sprite = back;
				gameController.GetComponent<GameController>().RemoveVisibleFace(faceIndex);
			}
		}
	}

	private void Awake()
	{
		gameController = GameObject.Find ("GameController");
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
}
