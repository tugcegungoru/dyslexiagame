using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	GameObject back;
	List<int> faceIndexes = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 0, 1, 2, 3, 4, 5, 6, 7 };
	public static System.Random rnd = new System.Random();
	public int shuffleNum = 0;
	int[] visibleFaces = { -1, -2 };
	int sayac = 0;
	private int currentTime;


	private void Start()
	{
		float yPosition = 9.5f;
		float xPosition = -17f;
		int originalLength = faceIndexes.Count;
		currentTime = 0;

		for (int i = 0; i < 15; i++)
		{
			shuffleNum = rnd.Next(0, (faceIndexes.Count));
			var temp = Instantiate(back, new Vector3(
				xPosition, yPosition, 0),
				Quaternion.identity);
			temp.GetComponent<MainToken>().faceIndex = faceIndexes[shuffleNum];
			faceIndexes.Remove(faceIndexes[shuffleNum]);
			xPosition = xPosition + 8;
			if (i == (originalLength / 2 - 2))
			{
				yPosition = yPosition - 6;
				xPosition = -25f;
			}
		}
		back.GetComponent<MainToken>().faceIndex = faceIndexes[0];
	}

	public bool TwoCardsUp()
	{
		bool cardsUp = false;
		if (visibleFaces[0] >= 0 && visibleFaces[1] >= 0)
		{
			cardsUp = true;
		}
		return cardsUp;
	}

	public void AddVisibleFace(int index)
	{
		if (visibleFaces[0] == -1)
		{
			visibleFaces[0] = index;
		}
		else if (visibleFaces[1] == -2)
		{
			visibleFaces[1] = index;
		}
	}

	public void RemoveVisibleFace(int index)
	{
		if (visibleFaces[0] == index)
		{
			visibleFaces[0] = -1;
		}
		else if (visibleFaces[1] == index)
		{
			visibleFaces[1] = -2;
		}
	}

	public bool CheckMatch()
	{
		bool success = false;
		if (visibleFaces[0] == visibleFaces[1])
		{
			visibleFaces[0] = -1;
			visibleFaces[1] = -2;
			success = true;

			sayac++;
			if (sayac == 8)
			{
				onMenu();
			}
		}
		return success;
	}

	private void Awake()
	{
		back = GameObject.Find("back");
	}

	public void onMenu()
	{
		Debug.Log(second);
		Debug.Log(minute);
		Application.LoadLevel("MainMenu");
	}

	public float second, minute;
	public Text timeText;
	// Start is called before the first frame update

	// Update is called once per frame
	void Update()
	{
		timeText.text = "" + minute.ToString("00") + ":" + second.ToString("00");
		second += Time.deltaTime;
		if (second > 59)
		{
			minute += 1;
			second = 0;
		}
		PlayerPrefs.SetFloat("second", second);
		PlayerPrefs.SetFloat("minute", minute);
	}
}
