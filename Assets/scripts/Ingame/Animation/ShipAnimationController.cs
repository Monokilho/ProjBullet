using UnityEngine;
using System.Collections;

public class ShipAnimationController : MonoBehaviour {
	public SpriteRenderer ShipSprite;
	AnimationsHolder shipanimator;

	string horizontal;
	string vertical;

	bool iddle;
	bool moving;

	int state;
	int currentframe;
	float timecount;
	float framelength;
	int lastframe;
	public void Init(AnimationsHolder animations, float framelength,int last){
		lastframe = last-1;
		shipanimator = animations;
		iddle = true;
		this.framelength = framelength;
		if (staticstuff.config.use_mouse) {
			horizontal="MouseHorizontal";
			vertical="MouseVertical";
		}
		else{
			horizontal="Horizontal";
			vertical="Vertical";
			
		}
	}
	// Update is called once per frame
	void Update () {
		updateanimation ();
		Debug.Log ("is idle " + iddle);
		if (iddle) {
			if (Input.GetAxis (horizontal) > 0) {
				Debug.Log ("start right animation");
				startAnimation (1);
			} else if (Input.GetAxis (horizontal) < 0) {
				startAnimation (7);
			} else if (Input.GetAxis (vertical) > 0) {
				startAnimation (4);
			} else if (Input.GetAxis (vertical) < 0) {
				startAnimation (10);
			}
		} else {
			if(!moving){
				if(Input.GetAxis (horizontal) !=1 && state == 2){
					startAnimation(3);
				}
				else if(Input.GetAxis (horizontal) !=-1 && state == 8){
					startAnimation(9);
				}
				else if(Input.GetAxis (vertical) !=1 && state == 5){
					startAnimation(6);
				}
				else if(Input.GetAxis (vertical) !=-1 && state == 11){
					startAnimation(12);
				}
			}
			else{

			}

		}



	}

	void updateanimation(){
		if (state == 1) {
			timecount += Time.deltaTime;
			if(timecount>framelength){
				Debug.Log ("updating to frame " + currentframe);
				timecount=0;
				currentframe++;
				if(currentframe<3)
					ShipSprite.sprite=shipanimator.RightAnimation[currentframe];
				else{
					ShipSprite.sprite=shipanimator.IddleRight;
					state=2;
					moving=false;
				}
			}
		}
		else if (state == 3) {
			timecount += Time.deltaTime;
			if(timecount>framelength){
				Debug.Log ("updating to frame " + currentframe);
				timecount=0;
				currentframe--;
				if(currentframe>=0)
					ShipSprite.sprite=shipanimator.RightAnimation[currentframe];
				else{
					ShipSprite.sprite=shipanimator.Iddle;
					state=0;
					moving=false;
					iddle=true;
				}
			}
		}
		else if (state == 4) {
			timecount += Time.deltaTime;
			if(timecount>framelength){
				timecount=0;
				currentframe++;
				if(currentframe<3)
					ShipSprite.sprite=shipanimator.UpAnimation[currentframe];
				else{
					ShipSprite.sprite=shipanimator.IddleUp;
					state=5;
					moving=false;
				}
			}
		}
		else if (state == 6) {
			timecount += Time.deltaTime;
			if(timecount>framelength){
				timecount=0;
				currentframe--;
				if(currentframe>=0)
					ShipSprite.sprite=shipanimator.UpAnimation[currentframe];
				else{
					ShipSprite.sprite=shipanimator.Iddle;
					state=0;
					moving=false;
					iddle=true;
				}
			}
		}
		else if (state == 7) {
			timecount += Time.deltaTime;
			if(timecount>framelength){
				timecount=0;
				currentframe++;
				if(currentframe<3)
					ShipSprite.sprite=shipanimator.LeftAnimation[currentframe];
				else{
					ShipSprite.sprite=shipanimator.IddleLeft;
					state=8;
					moving=false;
				}
			}
		}
		else if (state == 9) {
			timecount += Time.deltaTime;
			if(timecount>framelength){
				timecount=0;
				currentframe--;
				if(currentframe>=0)
					ShipSprite.sprite=shipanimator.LeftAnimation[currentframe];
				else{
					ShipSprite.sprite=shipanimator.Iddle;
					state=0;
					moving=false;
					iddle=true;
				}
			}
		}
		else if (state == 10) {
			timecount += Time.deltaTime;
			if(timecount>framelength){
				timecount=0;
				currentframe++;
				if(currentframe<3)
					ShipSprite.sprite=shipanimator.DownAnimation[currentframe];
				else{
					ShipSprite.sprite=shipanimator.IddleDown;
					state=11;
					moving=false;
				}
			}
		}
		else if (state == 12) {
			timecount += Time.deltaTime;
			if(timecount>framelength){
				timecount=0;
				currentframe--;
				if(currentframe>=0)
					ShipSprite.sprite=shipanimator.DownAnimation[currentframe];
				else{
					ShipSprite.sprite=shipanimator.Iddle;
					state=0;
					moving=false;
					iddle=true;
				}
			}
		}

	}

	void startAnimation(int state){
		if (state == 1) {
			this.state=state;
			ShipSprite.sprite=shipanimator.RightAnimation[0];
			timecount=0;
			iddle=false;
			currentframe=0;
			moving=true;
		}
		else if (state == 3) {
			this.state=state;
			ShipSprite.sprite=shipanimator.RightAnimation[lastframe];
			timecount=0;
			iddle=false;
			currentframe=lastframe;
			moving=true;
		}
		else if (state == 4) {
			this.state=state;
			ShipSprite.sprite=shipanimator.UpAnimation[0];
			timecount=0;
			iddle=false;
			currentframe=0;
			moving=true;
		}
		else if (state == 6) {
			this.state=state;
			ShipSprite.sprite=shipanimator.UpAnimation[lastframe];
			timecount=0;
			iddle=false;
			currentframe=lastframe;
			moving=true;
		}
		else if (state == 7) {
			this.state=state;
			ShipSprite.sprite=shipanimator.LeftAnimation[0];
			timecount=0;
			iddle=false;
			currentframe=0;
			moving=true;
		}
		else if (state == 9) {
			this.state=state;
			ShipSprite.sprite=shipanimator.LeftAnimation[lastframe];
			timecount=0;
			iddle=false;
			currentframe=lastframe;
			moving=true;
		}
		else if (state == 10) {
			this.state=state;
			ShipSprite.sprite=shipanimator.DownAnimation[0];
			timecount=0;
			iddle=false;
			currentframe=0;
			moving=true;
		}
		else if (state == 12) {
			this.state=state;
			ShipSprite.sprite=shipanimator.DownAnimation[lastframe];
			timecount=0;
			iddle=false;
			currentframe=lastframe;
			moving=true;
		}
	}
}
