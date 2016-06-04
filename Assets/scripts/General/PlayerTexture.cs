using UnityEngine;
using System.Collections;

public class PlayerTexture {

	public Texture2D sprite{
		get;
		set;
	}
	public TextureConfig config{
		get;
		set;
	}

	public PlayerTexture(Texture2D sprite, TextureConfig config){
		this.sprite = sprite;
		this.config = config;


	}



}
