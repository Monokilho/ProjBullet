using UnityEngine;
using System.Collections;

public class ShipControl : MonoBehaviour {
	public float HP;
	public string playername;
	public HudControl hud;

	// Use this for initialization
	void Start () {
		if (playername.Equals ("Player"))
			hud.setPlayerHp (HP);
		else {
			hud.setEnemyHp (HP);
		
		}
	}
	
	public void hit(float dmg){

		HP = HP - dmg;
		if (HP <= 0) {
			Debug.Log (playername+" dead");
		}
		if (playername.Equals ("Player"))
			hud.playerhit (dmg);
		else
			hud.enemyhit (dmg);
	}


}
