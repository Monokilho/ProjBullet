using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;
using LuaInterface;
using System.IO;
using System.Collections.Generic;
using System;
using NAudio.Wave;

public static  class Loaders {


	public static void LoadPlayerScripts(){
		Regex luaregex = new Regex ("(lua)$");
		staticstuff.loadedScripts = new List<PlayerScripts> ();

		DirectoryInfo playerscripts = new DirectoryInfo (staticstuff.config.scriptpath);
		FileInfo[] files = playerscripts.GetFiles();
		for (int i=0; i<files.Length; i++) {
			//check file missing
			if(luaregex.Match (files[i].Name).Success){
				Debug.Log ("loading "+files[i].Name);
				Lua luafile = new Lua();
				luafile.DoFile(files[i].FullName);
				if((bool) luafile["IsDefault"])
				   staticstuff.defaultScript = new PlayerScripts((string) luafile["Name"], luafile, (bool) luafile["IsDefault"]) ;
				else
					staticstuff.loadedScripts.Add(new PlayerScripts((string) luafile["Name"], luafile, (bool) luafile["IsDefault"]));
			}
		}
	}
	
	public static void LoadPlayerMusic(){
		Regex mp3regex = new Regex ("(mp3)$");
		Regex wavregex = new Regex ("(wav)$");
		Regex[] csvregex = new Regex[4] {new Regex("(Beat.csv)$"),new Regex("(Onset.csv)$"),new Regex("(Pitch.csv)$"),new Regex("(Segment.csv)$")};

		DirectoryInfo playermusic = new DirectoryInfo (staticstuff.config.musicpath);
		DirectoryInfo[] musicdirs = playermusic.GetDirectories ();;
		for(int i=0;i<musicdirs.Length;i++){
			FileInfo[] files = musicdirs[i].GetFiles();
			//convert all mp3 files to wav
			for(int j=0;j<files.Length;j++){
				if(mp3regex.Match(files[j].Name).Success){
					Mp3ToWav(files[j].FullName,musicdirs[i]+"/"+Path.GetFileNameWithoutExtension(files[j].Name)+".wav");
				}
			}
			//initialize storage
			staticstuff.loadedmusics = new List<Music>();
			//get all new files
			files = musicdirs[i].GetFiles();
			bool[] foundallfiles = new bool[5];
			FileInfo[] musicfiles = new FileInfo[5];
			for(int j=0;j<files.Length;j++){
				
				if(wavregex.Match(files[j].Name).Success){
					musicfiles[0] = files[j];
					foundallfiles[0]=true;
				}
				
				if(csvregex[0].Match(files[j].Name).Success){
					musicfiles[1] = files[j];
					foundallfiles[1]=true;
				}
				
				if(csvregex[1].Match(files[j].Name).Success){
					musicfiles[2] = files[j];
					foundallfiles[2]=true;
				}
				
				if(csvregex[2].Match(files[j].Name).Success){
					musicfiles[3] = files[j];
					foundallfiles[3]=true;
				}
				
				if(csvregex[3].Match(files[j].Name).Success){
					musicfiles[4] = files[j];
					foundallfiles[4]=true;
				}
				
			}
			if(Array.TrueForAll(foundallfiles,delegate (bool x) { return x; })){
				Music music = new Music();
				music.name = musicdirs[i].Name;
				music.audio=loadwav(musicfiles[0]);
				music.beat=loadcsv(musicfiles[1]);
				music.onset=loadcsv(musicfiles[2]);
				music.pitch=loadcsv(musicfiles[3]);
				music.segment=loadcsv(musicfiles[4]);
				staticstuff.loadedmusics.Add(music);
			}
			else{
				Debug.Log ("files missing on " + musicdirs[i].Name);
			}
		}
		
	}
	public static void loadTexture(){

		Regex xmlregex = new Regex ("(xml)$");
		Regex pngregex = new Regex ("(png)$");
		DirectoryInfo spritesfolder = new DirectoryInfo (staticstuff.config.spritespath);
		FileInfo[] files = spritesfolder.GetFiles();
		staticstuff.loadedsprites = new List<PlayerTexture>();
		for (int i=0; i<files.Length; i++) {
			//check file missing
			if(xmlregex.Match (files[i].Name).Success){
				Debug.Log ("loading "+files[i].Name);
				TextureConfig textureconf;
				try{
					textureconf =(TextureConfig) XmlSerialization.Deserialize(files[i].FullName, new TextureConfig());
				}
				catch(Exception e){
					Debug.Log("error loading texture .txt file name:"+files[i].Name +"\n" + e);
					continue;
				}
				if(!pngregex.Match (textureconf.file_path).Success){
					Debug.Log("image file load is not PNG");
					continue;
				}

				Texture2D texture = new Texture2D(2,2);
				try{
					if (!File.Exists(textureconf.file_path))     {
						throw new Exception();
					}
					byte[] fileData = File.ReadAllBytes(textureconf.file_path);
					texture.LoadImage(fileData);
				}
				catch (Exception e){
					Debug.Log("error loading texture .png file name:"+textureconf.file_path +"\n" + e);
					continue;
				}

				staticstuff.loadedsprites.Add(new PlayerTexture(texture,textureconf));
				Debug.Log("Loaded "+ textureconf.name);
			}
		}

	}
	
	// auxiliars functions
	private static void Mp3ToWav(string mp3File, string outputFile)
	{
		using (Mp3FileReader reader = new Mp3FileReader(mp3File))
		{
			WaveFileWriter.CreateWaveFile(outputFile, reader);
		}
	}
	
	private static AudioClip loadwav (FileInfo fileInfo)
	{
		WWW www =new WWW ("file://" + fileInfo.FullName);
		AudioClip audio = www.audioClip;
		bool ready = false;
		while (!ready) {
			if(audio.loadState == AudioDataLoadState.Loaded)
				ready=true;
			else if(audio.loadState == AudioDataLoadState.Failed)
				Debug.Log ("something went terribly wrong loading audio");	
		}

		return audio;
	}
	
	private static string loadcsv (FileInfo fileInfo)
	{
		return File.ReadAllText (fileInfo.FullName);
	}



}
