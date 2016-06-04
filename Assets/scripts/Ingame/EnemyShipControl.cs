using UnityEngine;
using System.Collections;

public class EnemyShipControl : MonoBehaviour {


	public Rigidbody2D body;
	public float speed;
	public int punchdmg;
	public Vector2 punchback;
	public float HP;
	public string enemyname;
	public HudControl hud;



	// Use this for initialization
	public void sethp (int hp) {
		HP = hp;
		hud.setEnemyHp (HP);
	}
	
	// Update is called once per frame
	void Update () {
		body.AddForce(new Vector2(speed,0));
	}

	public void hit(float dmg){
		
		HP = HP - dmg;
		if (HP <= 0) {
			Debug.Log (enemyname+" dead");
		}
			hud.enemyhit (dmg);
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.CompareTag ("GUI"))
			speed = speed * -1;
		else if (col.gameObject.CompareTag ("Player")) {
			col.gameObject.GetComponent<PlayerShipControl> ().hit (punchdmg);
			col.gameObject.GetComponent<PlayerShipControl> ().forceback (punchback);
		}
	}
}
