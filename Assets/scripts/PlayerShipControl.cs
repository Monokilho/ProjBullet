using UnityEngine;
using System.Collections;

public class PlayerShipControl : MonoBehaviour {
	public float HP;
	public string player_name;
	public HudControl hud;
	public Rigidbody2D rb;
	public float Xvelocity;
	public float Yvelocity;
	public GameObject defaultbullet;
	public GameObject origin;
	public bool usemouse;
	public Vector2 fireforce;
	public float mousesensitivity;
	public float bulletdmg;
	bool lockmovement;
	Vector2 punchforce;

	public void sethp (int hp) {
		HP = hp;
		hud.setPlayerHp (HP);
		}

	void Update () {
		if (!lockmovement) {
			if (!usemouse) {
				rb.velocity = new Vector2 (Input.GetAxis ("Horizontal") * Xvelocity, Input.GetAxis ("Vertical") * Yvelocity);
			
			} else {
				/*Vector3 mousePos = Input.mousePosition;
				Vector3 wantedPos = Camera.main.ScreenToWorldPoint (new Vector3 (mousePos.x, mousePos.y, 1));*/
			
				//rb.MovePosition (wantedPos);
				//transform.position = wantedPos;
			
				rb.velocity = new Vector2 (Input.GetAxis ("MouseHorizontal")*mousesensitivity, Input.GetAxis ("MouseVertical")*mousesensitivity);
			}

		} else {
			rb.velocity=punchforce;
		}
		if (Input.GetButtonDown ("Fire1"))
			fire ();	
	}

	void fire(){
		GameObject firingbullet = GameObject.Instantiate (defaultbullet, origin.transform.position, Quaternion.identity) as GameObject;
		firingbullet.transform.parent=origin.transform;
		firingbullet.GetComponent<BulletScript> ().dmg = bulletdmg;
		Rigidbody2D rb = firingbullet.GetComponent<Rigidbody2D>();
		rb.AddForce(fireforce);
	}

	public void hit(float dmg){
		
		HP = HP - dmg;
		if (HP <= 0) {
			Debug.Log (player_name+" dead");
		}
			hud.playerhit (dmg);

	}


	public void forceback (Vector2 punchback)
	{
		lockmovement = true;
		punchforce = punchback;
		//rb.AddForce (punchback);
	}


	void OnCollisionEnter2D(Collision2D col)
	{	
		if (col.gameObject.CompareTag ("GUI") && lockmovement)
			lockmovement = false;

	}
}


