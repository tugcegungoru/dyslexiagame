using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowPuzzleEnd : MonoBehaviour
{
	int sumanimal = 3;
	int first_an = 0;
  
	public void level_end()
	{
		first_an++;
		if(first_an == sumanimal)
		{
			Debug.Log("OYUN BİTTİ");
		}
	}
}
