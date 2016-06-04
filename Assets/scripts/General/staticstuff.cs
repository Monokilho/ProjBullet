using UnityEngine;
using System.Collections;
using LuaInterface;
using System.Collections.Generic;

public static class staticstuff {
	public static Configs config{
		get;
		set;
	}
	
	public static Music SelectedMusic {
		get;
		set;
	}
	public static List<PlayerScripts> loadedScripts {
		get;
		set;
	}

	public static List<PlayerScripts> SelectedScripts {
		get;
		set;
	}

	public static PlayerScripts defaultScript{
		get;
		set;
	}


	public static List<Music> loadedmusics{
	get;
	set;
	}

	public static List<PlayerTexture> loadedsprites{
		get;
		set;
	}
	public static PlayerTexture SelectedSprite {
		get;
		set;
	}
}
