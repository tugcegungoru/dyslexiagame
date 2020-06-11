using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowPuzzleMove : MonoBehaviour
{
	Camera camera;
	GameObject[] shadows;
	Vector2 start_pos;
	ShadowPuzzleEnd end_script;
	int sayac;
    // Start is called before the first frame update
    void Start()
    {
		camera = GameObject.Find("Main Camera").GetComponent<Camera>();
		shadows = GameObject.FindGameObjectsWithTag("gölge");
		start_pos = transform.position;
		end_script = GameObject.Find("son").GetComponent<ShadowPuzzleEnd>();
    }

	private void OnMouseDrag()
	{
		Vector3 pos = camera.ScreenToWorldPoint(Input.mousePosition); //ekranda dokunulan yerleri verir
		pos.z = 0;
		transform.position = pos;

	}

	// Update is called once per frame
	void Update()
    {
		if (Input.GetMouseButtonUp(0)) //mouse butonunu bıraktığım zaman
		{
			foreach (GameObject shadow in shadows)
			{
				if(gameObject.name == shadow.name)
				{
					float distance = Vector3.Distance(shadow.transform.position, transform.position);
					if (distance <= 1)
					{
						transform.position = shadow.transform.position;
						Destroy(this);
						end_script.level_end();
						sayac++;
						Debug.Log(sayac);
					}
					else
					{
						transform.position = start_pos;
					}
				}
			}
		}
    }
}
