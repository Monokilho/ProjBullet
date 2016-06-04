using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MessageScript : MonoBehaviour {
	public AudioSource endbgm;
	public AudioClip win;
	public AudioClip lose;
	public AudioClip tie;
	public Text text;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			Cursor.visible = true;
			Application.LoadLevel(1);
		
		}

	}

	public void gameEnd (int i)
	{
		switch (i) {
		case(0):{endbgm.clip=lose;text.text="You Lose";break;}
		case(1):{endbgm.clip=win;text.text="You Win";break;}
		case(2):{endbgm.clip=lose;text.text="Time Over";break;}
		}
		endbgm.Play();
	}
}
