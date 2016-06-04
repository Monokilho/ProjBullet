using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class BulletControler : MonoBehaviour {
	public MusicInfoScript musicinfo;
	public AudioSource audiosource;
	bool running;
	public Rigidbody2D enemyrb;
	Dictionary<int, IPattern> patternIndex;
	int typeindex;
	int onsetindex;
	int aux;
	// Use this for initialization
	void Start () {
		running = false;
		typeindex = 0;
		onsetindex = 0;
		aux = 0;
	}
	
	// Update is called once per frame
	void Update () {
		float curtime = audiosource.time;
		if (typeindex <= musicinfo.onsetbysecond.Length)
			while (curtime > musicinfo.onsetbysecond[typeindex]) {
			if(musicinfo.bullettypebyonset [typeindex] == aux){
				patternIndex [musicinfo.bullettypebyonset [typeindex]].fire (onsetindex);
				onsetindex++;
			}
			else{
				aux=musicinfo.bullettypebyonset [typeindex];
				onsetindex=0;
				patternIndex [musicinfo.bullettypebyonset [typeindex]].fire (onsetindex);
				onsetindex++;
			}
				typeindex++;
			}
		else if(!running) {
			enemyrb.AddForce(new Vector2(0f,0.2f));
			running=true;
		}
	}

	public void loadBullets (System.Collections.Generic.Dictionary<int, IPattern> dictionary)
	{
		patternIndex = dictionary;
	}
}
