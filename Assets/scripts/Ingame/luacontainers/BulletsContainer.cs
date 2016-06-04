using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LuaInterface;

public class BulletsContainer  {

	public List<Object> bullets;
	public List<Vector2> forces;
	public GameObject defaultbullet;
	public List<Vector2> position;
	public GameObject origin;

	public BulletsContainer(GameObject defaultbullet,GameObject origin){
		bullets = new List<Object>();
		forces = new List<Vector2>();
		this.defaultbullet=defaultbullet;
		this.origin = origin;
		position = new List<Vector2>();
	}

}
