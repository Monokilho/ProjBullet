using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LuaInterface;

public class BulletSystemControl {
	GameObject defaultbullet;
	GameObject origin;
	GameObject bulletrepo;

	Dictionary<int,IPattern> patternindex;
	
	//List<GameObject> enroute = new List<GameObject>();
	// Use this for initialization
	public int particlePerSecond = 75;

	public BulletSystemControl(GameObject defaultbullet, GameObject origin,GameObject bulletrepo) {
		this.defaultbullet = defaultbullet;
		this.origin = origin;
		this.bulletrepo = bulletrepo;
		patternindex = new Dictionary<int,IPattern > ();
	}

	
	public Dictionary<int,IPattern> createBullets(){

		foreach (IPattern patscript in patternindex.Values) {
			patscript.initialize();
		
		}
		return patternindex;

	}
	

	public void createpatterns(MusicInfoScript musicinfo){

		foreach(TypeProperty typeprop in musicinfo.propertiesList){
			TypeMethods luatype = new TypeMethods(typeprop);
			PlayerScripts temp = null;
			foreach (PlayerScripts playerscript in staticstuff.SelectedScripts) {
				LuaFunction checkprop = playerscript.script.GetFunction("checkProp");
				object[] returnvalues = checkprop.Call(luatype);
				if((bool) returnvalues[0]){
					patternindex.Add(typeprop.segmentnumber,new LuaScriptFacade(playerscript.script,bulletrepo,origin,defaultbullet,luatype));
					temp=playerscript;
					break;
				}
			}
			if(temp!=null)
				staticstuff.SelectedScripts.Remove(temp);
			else{
				patternindex.Add(typeprop.segmentnumber,new LuaScriptFacade(staticstuff.defaultScript.script,bulletrepo,origin,defaultbullet,luatype));

			}
		}
		//if(musicinfo.patterntypes.Count!=0)
			//add remaining to default


	}
}
