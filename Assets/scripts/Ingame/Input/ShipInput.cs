using UnityEngine;
using System.Collections;

public class ShipInput : MonoBehaviour {
	public Rigidbody2D rb;
	public float Xvelocity;
	public float Yvelocity;
	public GameObject defaultbullet;
	public GameObject origin;
	public bool usemouse;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!usemouse) {
			rb.velocity = new Vector2 (Input.GetAxis ("Horizontal") * Xvelocity, Input.GetAxis ("Vertical") * Yvelocity);
		
		} else {
			Vector3 mousePos = Input.mousePosition;
			Vector3 wantedPos = Camera.main.ScreenToWorldPoint (new Vector3 (mousePos.x, mousePos.y, 1));

			rb.MovePosition(wantedPos);
			//transform.position = wantedPos;

			//rb.velocity = new Vector2 (Input.GetAxis ("MouseHorizontal") * Xvelocity, Input.GetAxis ("MouseVertical") * Yvelocity);
		}
		if (Input.GetButtonDown ("Fire1"))
			fire ();	
	}

	void fire(){
		GameObject firingbullet = GameObject.Instantiate (defaultbullet, origin.transform.position, Quaternion.identity) as GameObject;
		firingbullet.transform.parent=origin.transform;
		Rigidbody2D rb = firingbullet.GetComponent<Rigidbody2D>();
		rb.AddForce(new Vector2(0,0.1f));
	}
}
