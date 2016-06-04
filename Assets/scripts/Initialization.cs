using UnityEngine;
using System.Collections;
using System.IO;

public class Initialization : MonoBehaviour {

	// Use this for initialization
	void Start () {

		loadroutine ();
		Application.LoadLevel (1);
	}
	// Update is called once per frame
	void Update () {
	}

	void loadroutine(){

		staticstuff.config = new Configs();
		staticstuff.config = (Configs) XmlSerialization.Deserialize(Application.dataPath+"/config.xml", staticstuff.config);
		if (!System.IO.File.Exists (staticstuff.config.musicpath)) {
			Directory.CreateDirectory(staticstuff.config.musicpath);
		}
		if (!System.IO.File.Exists (staticstuff.config.scriptpath)) {
			Directory.CreateDirectory(staticstuff.config.scriptpath);
		}
		if (!System.IO.File.Exists (staticstuff.config.spritespath)) {
			Directory.CreateDirectory(staticstuff.config.spritespath);
		}

		//load musics
		Loaders.LoadPlayerMusic ();
		//load custom scripts
		Loaders.LoadPlayerScripts ();
		//load custom textures
		Loaders.loadTexture ();

	}
}
