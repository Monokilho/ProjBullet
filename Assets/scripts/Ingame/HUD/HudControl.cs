using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HudControl : MonoBehaviour {
	public AudioSource bgm;
	public Text time;
	public Slider playerhp;
	public Slider enemyhp;
	public int musiclenght;
	public GameObject MainObj;
	public GameObject finalobj;
	public MessageScript finalobjscript;

	// Use this for initialization
	void Start () {
		//musiclenght = (int)bgm.clip.length;


	}
	
	// Update is called once per frame
	void Update () {
		int lefttime =  musiclenght-(int)bgm.time;
		int leftsecond = lefttime % 60;
		int leftmin = lefttime / 60;
		time.text =  leftmin+":"+leftsecond;
		if (lefttime == 0) {
			finalobj.SetActive(true);
			finalobjscript.gameEnd(2);
			MainObj.SetActive(false);
		}
	}
	public void playerhit(float dmg){
		playerhp.value = playerhp.value - dmg;
		if(playerhp.value<=0){
			finalobj.SetActive(true);
			finalobjscript.gameEnd(0);
			MainObj.SetActive(false);
		}

	}

	public void enemyhit (float dmg)
	{
		enemyhp.value = enemyhp.value - dmg;
		if(enemyhp.value<=0){
			finalobj.SetActive(true);
			finalobjscript.gameEnd(1);
			MainObj.SetActive(false);
		}
	}

	public void setPlayerHp (float HP)
	{
		playerhp.maxValue = HP;
		playerhp.value = HP;
	}

	public void setEnemyHp (float HP)
	{
		enemyhp.maxValue = HP;
		enemyhp.value = HP;
	}
}
