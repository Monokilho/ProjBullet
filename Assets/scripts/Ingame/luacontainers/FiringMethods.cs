using UnityEngine;
using System.Collections;
using LuaInterface;
using System.Collections.Specialized;



public class FiringMethods  {

	private GameObject workingbullet;

	private int listIndex; 

	public void newFire(GameObject bullet, int listindex){
		this.listIndex = listindex;
		workingbullet=bullet;
	}

	public void setBulletColor(float red, float green, float blue){
		
		SpriteRenderer sprite = workingbullet.GetComponent<SpriteRenderer> ();
		sprite.color = new Color (red, green, blue);
		
	}
	
	public LuaTable getBulletColor(){
		
		SpriteRenderer sprite = workingbullet.GetComponent<SpriteRenderer> ();
		Lua temp = new Lua ();
		
		temp.NewTable ("bulletColor");
		temp.DoString ("bulletColor[\"red\"]=" + sprite.color.r);
		temp.DoString ("bulletColor[\"green\"]=" + sprite.color.g);
		temp.DoString ("bulletColor[\"blue\"]=" + sprite.color.b);
		
		return temp.GetTable ("bulletColor");
	}

	public int getIndex(){

		return listIndex;
	}
}
