using UnityEngine;
using System.Collections;
using System.IO;

public class LoadAnimation {
	string[] moveNames = {"player_default","default_down","full_down","down_default",
	                      "default_up","full_up","up_default",
	                      "default_left","full_left","left_default",
		"default_right","full_right","right_default"};


	public AnimationsHolder load(PlayerTexture playertex){
		Sprite[] animationsprites = divideTexture (playertex.sprite,playertex.config.frames_per_line,4,playertex.config.width,playertex.config.height,playertex.config.pixel_per_unit);
		AnimationsHolder animations = new AnimationsHolder ();
		int i = 0;
		animations.Iddle = animationsprites [i];
		i++;
		animations.DownAnimation=loadArray (animations.DownAnimation, animationsprites, playertex.config.frames_per_line, i);
		i = i + (playertex.config.frames_per_line - 2);
		animations.IddleDown = animationsprites [i];
		i = i + 2;
		animations.UpAnimation=loadArray (animations.UpAnimation, animationsprites, playertex.config.frames_per_line, i);
		i = i + (playertex.config.frames_per_line - 2);
		animations.IddleUp = animationsprites [i];
		i = i + 2;
		animations.LeftAnimation=loadArray (animations.LeftAnimation, animationsprites, playertex.config.frames_per_line, i);
		i = i + (playertex.config.frames_per_line - 2);
		animations.IddleLeft = animationsprites [i];
		i = i + 2;
		animations.RightAnimation=loadArray (animations.RightAnimation, animationsprites, playertex.config.frames_per_line, i);
		i = i + (playertex.config.frames_per_line - 2);
		animations.IddleRight = animationsprites [i];
 
		return animations;
	}
	Sprite[] loadArray(Sprite[] spritearray,Sprite[] animationsprites, int framesperline, int i){
		spritearray = new Sprite[framesperline - 2];
		for (int j=0; j<framesperline-2; j++,i++) {
			spritearray[j]= animationsprites[i];
		}
		return spritearray;
	}




	Sprite[] divideTexture (Texture2D tex,int x, int y, int width, int height, float units){
		Sprite[] spriteholder = new Sprite[x*y];

		for(int j=0;j<y;j++){
			for(int i=0;i<x;i++){
				Sprite temp = Sprite.Create(tex,new Rect(i*width,j*height,width,height),new Vector2(0.5f,0.5f),units);
				spriteholder[(j*x)+i]=temp;
				Debug.Log ((j*x)+i);
			}

		}
		return spriteholder;
	}


}

