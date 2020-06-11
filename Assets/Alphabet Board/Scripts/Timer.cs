using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

	public float second, minute;
	public Text timeText;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
		PlayerPrefs.SetFloat("second", second);
		PlayerPrefs.SetFloat("minute", minute);
		timeText.text = "" + minute.ToString("00")+ ":" + second.ToString("00");
		second += Time.deltaTime;
		if(second > 59)
		{
			minute += 1;
			second = 0;
		}
	}
}
