using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

public class MusicSelection : MonoBehaviour
{
	ToggleGroups<Music> musicgroup;
	ToggleGroups<PlayerTexture> spritegroup;
	ToggleGroups<PlayerScripts> scriptgroup;

	public GameObject sampleMusicToggle;
	public GameObject sampleSpriteToggle;
	public GameObject sampleScriptToggle;
	

	
	public Transform musicContentPanel;
	public Transform spriteContentPanel;
	public Transform scriptContentPanel;


	public GameObject mainmenu;
	public GameObject musicselection;


	public Button start;

	public MainControlScript motherbrain;
	void Update(){

		if (musicgroup.isEmpty () || spritegroup.isEmpty ()) {
			start.interactable = false;
		} else {
			start.interactable = true;
		}


	}

	public void startButton(){
	


		staticstuff.SelectedMusic =  musicgroup.getselect ();
		staticstuff.SelectedSprite = spritegroup.getselect ();
		staticstuff.SelectedScripts = scriptgroup.getMultipleSelect();
		Application.LoadLevel (2);

	}

	public void backButton(){
		musicselection.SetActive (false);
		mainmenu.SetActive (true);
	
	
	}

	public void cleanLists(){
		int i = musicContentPanel.childCount;
		i--;
		while (i>=0) {
			GameObject.Destroy(musicContentPanel.GetChild(i).gameObject);
			i--;
		}
		 i = spriteContentPanel.childCount;
		i--;
		while (i>=0) {
			GameObject.Destroy(spriteContentPanel.GetChild(i).gameObject);
			i--;
		}
		 i = scriptContentPanel.childCount;
		i--;
		while (i>=0) {
			GameObject.Destroy(scriptContentPanel.GetChild(i).gameObject);
			i--;
		}

	}

	public void createLists ()
	{
		musicgroup = new ToggleGroups<Music>(false);
		foreach (Music music in staticstuff.loadedmusics) {
			GameObject newtoggle = Instantiate (sampleMusicToggle) as GameObject;
			MusicSelectionToggle musictoggle = newtoggle.GetComponent<MusicSelectionToggle> ();
			musictoggle.textbox.text = music.name;
			musictoggle.music= music;
			musictoggle.toggle.onValueChanged.AddListener(delegate{onMusicClick(musictoggle);});
			newtoggle.transform.SetParent (musicContentPanel);
		}
	
		spritegroup = new ToggleGroups<PlayerTexture> (false);
		foreach (PlayerTexture text in staticstuff.loadedsprites) {
			GameObject newtoggle = Instantiate (sampleSpriteToggle) as GameObject;
			SpriteSelectionToggle spritetoggle = newtoggle.GetComponent<SpriteSelectionToggle> ();
			spritetoggle.sprite_name.text = text.config.name;
			spritetoggle.sprite = text;
			spritetoggle.toggle.onValueChanged.AddListener(delegate{onSpriteClick(spritetoggle);});
			newtoggle.transform.SetParent (spriteContentPanel);
		}

		scriptgroup = new ToggleGroups<PlayerScripts> (true);
		foreach (PlayerScripts script in staticstuff.loadedScripts) {
			GameObject newtoggle = Instantiate (sampleScriptToggle) as GameObject;
			ScriptSelectionToggle scripttoggle = newtoggle.GetComponent<ScriptSelectionToggle> ();
			scripttoggle.script_name.text = script.name;
			scripttoggle.script = script;
			scripttoggle.toggle.onValueChanged.AddListener(delegate{onScriptClick(scripttoggle);});
			newtoggle.transform.SetParent (scriptContentPanel);
		}

	}

	void onMusicClick (MusicSelectionToggle clickedtoggle)
	{
		if (clickedtoggle.toggle.isOn) {
			musicgroup.add (clickedtoggle.toggle,clickedtoggle.music);

		} else {
			musicgroup.remove (clickedtoggle.toggle,clickedtoggle.music);

		}
	}

	void onSpriteClick (SpriteSelectionToggle clickedtoggle)
	{
		if (clickedtoggle.toggle.isOn) {
			spritegroup.add (clickedtoggle.toggle,clickedtoggle.sprite);
			
		} else {
			spritegroup.remove (clickedtoggle.toggle,clickedtoggle.sprite);
			
		}
	}



	void onScriptClick (ScriptSelectionToggle clickedtoggle)
	{
		if (clickedtoggle.toggle.isOn) {
			scriptgroup.add (clickedtoggle.toggle,clickedtoggle.script);
			
		} else {
			scriptgroup.remove (clickedtoggle.toggle,clickedtoggle.script);
			
		}
	}
}
