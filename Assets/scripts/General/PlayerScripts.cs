using UnityEngine;
using System.Collections;
using LuaInterface;

public class PlayerScripts{
	
	public string name;
	public Lua script;
	public bool isdefault;


	public PlayerScripts(string name, Lua script, bool isdefault){
		this.name = name;
		this.script = script;
		this.isdefault = isdefault;
	}
}
