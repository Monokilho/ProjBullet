using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour
{
	
	public int bullettype;
	public float dmg;
	public bool isactive;

	void Start ()
	{
	}

	// Update is called once per frame
	void Update ()
	{
		if (isactive)
		if (!GetComponent<Renderer> ().isVisible) {
			//Debug.Log ("destroy on update");
			//Debug.Log (transform.position);
			Destroy (gameObject);
		}
	
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.CompareTag ("Player"))
			col.gameObject.GetComponent<PlayerShipControl> ().hit (dmg);
		else if (col.gameObject.CompareTag ("Enemy"))
			col.gameObject.GetComponent<EnemyShipControl> ().hit (dmg);

		//Debug.Log ("destroy on collision");
		Destroy (gameObject);
	}
}
