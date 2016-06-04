using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using System.Text.RegularExpressions;
using NAudio;
using NAudio.Wave;
using System;
using System.Reflection;
using System.Text;
using LuaInterface;

public class MainMenuButtons : MonoBehaviour {
	public GameObject MainMenu;
	public GameObject Options;
	public MusicSelection musicselect;

	public void Playbutton(){
		Debug.Log ("Listing musics");
		musicselect.cleanLists ();
		musicselect.createLists ();
		musicselect.gameObject.SetActive (true);
		MainMenu.SetActive (false);
	}

	public void Optionsbutton(){
		Options.GetComponent<OptionsMenu>().mousesensitivity.value=staticstuff.config.mouse_sensitivity;
		Options.GetComponent<OptionsMenu>().usemouse.isOn=staticstuff.config.use_mouse;
		MainMenu.SetActive (false);
		Options.SetActive (true);
	}


	public void Exitbutton(){
		Application.Quit ();
	}


}
