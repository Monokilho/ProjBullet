using UnityEngine;
using System.Collections;

public  class MainControlScript :MonoBehaviour {

	 CSVParser parser;
	 MusicProcessor musicprocess;
 	BulletSystemControl bulletsystem;
 	MusicInfoScript musicinfo;
	LoadAnimation loadanim;
 	public BulletControler bulletcontroler;
 	public AudioSource match_music;
 	public string Onsetfile;
 	public string segmentfile;
 	public string Beatfile;
 	public string Pitchfile;
	public GameObject origin;
	public GameObject defaultenemybullet;
	public GameObject bulletrepo;
	AnimationsHolder animations;
	public ShipAnimationController shipanimations;
	public PlayerShipControl player;
	public EnemyShipControl enemy;
	public HudControl hud;
	public BoxCollider2D colliderbox;
	// Use this for initialization

	void Start () {
		match_music.clip = staticstuff.SelectedMusic.audio;
		Onsetfile = staticstuff.SelectedMusic.onset;
		segmentfile = staticstuff.SelectedMusic.segment;
		Beatfile = staticstuff.SelectedMusic.beat;
		Pitchfile = staticstuff.SelectedMusic.pitch;

		parser = new CSVParser ();
		musicinfo = new MusicInfoScript ();
		musicprocess = new MusicProcessor (musicinfo);
		bulletsystem = new BulletSystemControl (defaultenemybullet, origin,bulletrepo);
		bulletcontroler.musicinfo = musicinfo;


		musicprocess.processMusicOnset(parser.parseFile (Onsetfile));
		musicprocess.processMusicSegment (parser.parseFile (segmentfile));
		musicprocess.processMusicBeat (parser.parseFile (Beatfile));
		musicprocess.processMusicPitch (parser.parseFile (Pitchfile));
		Debug.Log ("music loaded");

		musicinfo.calculateValues ();
		Debug.Log ("Info calced");

		bulletsystem.createpatterns (musicinfo);
		Debug.Log ("Patterns loaded");

		bulletcontroler.loadBullets(bulletsystem.createBullets());
		Debug.Log ("bullets created");


		loadanim = new LoadAnimation ();
		animations=loadanim.load (staticstuff.SelectedSprite);
		shipanimations.Init (animations,staticstuff.SelectedSprite.config.frame_length,staticstuff.SelectedSprite.config.frames_per_line-2);
		colliderbox.size=  (new Vector2 ((float)(staticstuff.SelectedSprite.config.width/staticstuff.SelectedSprite.config.pixel_per_unit*0.6),(float)(staticstuff.SelectedSprite.config.height/staticstuff.SelectedSprite.config.pixel_per_unit*0.6)));
		Debug.Log ("sprite loaded");


		player.Xvelocity = staticstuff.config.x_velocity;
		player.Yvelocity = staticstuff.config.y_velocity;
		player.usemouse = staticstuff.config.use_mouse;
		player.mousesensitivity =staticstuff.config.mouse_sensitivity;
		Debug.Log ("loaded config");

		int musiclength = (int)match_music.clip.length;


		enemy.sethp (7 * (musiclength / 10));
		player.sethp (5 * (musiclength / 10));
		enemy.punchdmg = (int)player.HP / 20;

		hud.musiclenght = musiclength;
		bulletcontroler.audiosource.Play();
		Cursor.visible = false;
		Debug.Log ("Music activated START THE HELL");

	}

}
