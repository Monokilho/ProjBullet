using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LuaInterface;

public class LuaScriptFacade :IPattern{

	private Lua script;
	private LuaFunction initroutine;
	private LuaFunction fireroutine;
	private InitializerMethods luainit;
	private FiringMethods luafire;
	private TypeMethods luatype;
	private BulletsContainer container;
	public LuaScriptFacade(Lua script, GameObject bulletrepo, GameObject origin,GameObject defaultBullet,TypeMethods luatype){
		this.script = script;
		this.luatype = luatype;
		container = new BulletsContainer(defaultBullet,origin);
		luainit = new InitializerMethods (container,bulletrepo);
		luafire = new FiringMethods ();
		initroutine = script.GetFunction ("Initialize");
		fireroutine = script.GetFunction ("Fire");
	}

	public void initialize (){
		initroutine.Call (luainit,luatype);
		/*int i = container.bullets.Count;
		Debug.Log (i);
		i--;
		while (i>=0) {
			GameObject tempbullet = (GameObject)container.bullets[i];
			tempbullet.transform.parent = container.origin.transform;
			container.bullets[i]=tempbullet;
			i--;
		}
*/
	}
	
	public void fire (int listindex){
		int bulletindex = 0;
		int forcessize = container.forces.Count;
		int bulletsize = container.bullets.Count;
		for (int i=0; i<bulletsize; i++) {
			GameObject firingbullet = GameObject.Instantiate(container.bullets[i]) as GameObject;
			luafire.newFire(firingbullet,listindex);
			fireroutine.Call (luafire,luatype);
			firingbullet.GetComponent<Rigidbody2D>().AddForce((Vector2) container.forces[bulletindex]);
			firingbullet.transform.parent = container.origin.transform;
			Vector2 pos = container.position[i];
			firingbullet.transform.localPosition = pos;
			bulletindex++;
			if(bulletindex == forcessize)
				bulletindex=0;
		}
			if(Input.GetKey(KeyCode.F1))
				Debug.Log((string) script["debugname"]);
	}
	
}
