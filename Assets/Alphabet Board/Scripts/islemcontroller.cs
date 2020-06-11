using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class islemcontroller : MonoBehaviour
{
	
	public AudioSource source;

	public void onAdd(int deger)
	{
		Application.LoadLevel("MathAdd");
	}

	public void onSub()
	{
		Application.LoadLevel("MathSub");
	}

	public void onMult()
	{
		Application.LoadLevel("MathMult");
	}
	public void onDiv()
	{
		Application.LoadLevel("MathDiv");
	}
	public void onKarisik()
	{
		Application.LoadLevel("MathGame");
	}
	public void onMenu()
	{
		Application.LoadLevel("MainMenu");
	}
}