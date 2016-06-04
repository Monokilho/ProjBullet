using UnityEngine;
using System.Collections;
using LuaInterface;
using System.Collections.Generic;

public class InitializerMethods  {

	private BulletsContainer container;
	private GameObject workingbullet;
	private Vector2 workingposition;

	public InitializerMethods(BulletsContainer container, GameObject bulletrepo){
		this.container = container;
	}
	
	public void newbullet(){

		workingbullet = GameObject.Instantiate (container.defaultbullet) as GameObject;
		workingposition = new Vector2 (0f,0f);
	}

	public object[] getBulletPosition(){
		Lua temp = new Lua ();
		temp.DoString ("x=" + workingposition.x);
		temp.DoString ("y=" + workingposition.y);
		
		return temp.DoString ("return x,y");
	}
	
	public void setBulletPosition(float x, float y){
		workingposition.Set(x, y);
	}
	
	public object[] getOriginPosition(){
		/*Vector3 pos = container.origin.transform.position;
		/emp.DoString ("x=" + pos.x);
		temp.DoString ("y=" + pos.y);
		*/
		Lua temp = new Lua ();
		return temp.DoString ("return 0,0");
	}

	public void setBulletColor(float red, float green, float blue){

		SpriteRenderer sprite = workingbullet.GetComponent<SpriteRenderer> ();
		sprite.color = new Color (red, green, blue);

	}

	public object[] getBulletColor(){

		SpriteRenderer sprite = workingbullet.GetComponent<SpriteRenderer> ();
		Lua temp = new Lua ();

		temp.DoString ("red=" + sprite.color.r);
		temp.DoString ("green=" + sprite.color.g);
		temp.DoString ("blue=" + sprite.color.b);

		return temp.DoString("return red,green,blue");
	}

	public void setForce(float x, float y){
		
		Vector2 f = new Vector2(x, y);
		
		container.forces.Add (f);
	}

	public void storeBullet(){
		workingbullet.GetComponent<BulletScript> ().isactive = false;
		container.bullets.Add (workingbullet);
		container.position.Add (workingposition);
	}

}
