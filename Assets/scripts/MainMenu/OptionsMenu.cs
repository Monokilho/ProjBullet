using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {
	public GameObject options;
	public GameObject mainmenu;
	public Slider mousesensitivity;
	public Toggle usemouse;

	public void musicbutton(){
		Loaders.LoadPlayerMusic ();
	}

	public void scriptbutton(){
		Loaders.LoadPlayerScripts ();
	}

	public void texturebutton(){
		Loaders.loadTexture();
	}

	public void backbutton(){
		staticstuff.config.mouse_sensitivity = mousesensitivity.value;
		staticstuff.config.use_mouse = usemouse.isOn;
		options.SetActive (false);
		mainmenu.SetActive (true);
	}


}
