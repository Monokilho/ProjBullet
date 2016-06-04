using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MusicProcessor {
	MusicInfoScript musicinfo;

	public MusicProcessor (MusicInfoScript musicinfo){
		this.musicinfo = musicinfo;
	}

	public void processMusicOnset (double[][] grid)
	{
		//process onset
		double[] onsetbysecond = grid [0];
		double[] onsetintervals = new double[onsetbysecond.Length-1];
		double average = 0;
		for (int i=0; i<onsetintervals.Length; i++) {
			onsetintervals[i]= onsetbysecond[i+1]-onsetbysecond[i];
			average = average + onsetintervals[i];
		}

		// **   Old code for segment division by onset duration ** 
		/*
		average = average / (double)(onsetintervals.Length);
		double break1 = average * 0.3;
		double break2 = average;
		double break3 = average + average * 0.5;
		int[] bullettypeonset = new int[onsetbysecond.Length];
		bullettypeonset [0] = -1;
		for (int i=1; i<bullettypeonset.Length; i++) {
			if(onsetintervals[i-1]<break1){
				bullettypeonset[i]=0;
				continue;
			}
			else if(onsetintervals[i-1]<break2){
				bullettypeonset[i]=1;
				continue;
			}
			else if(onsetintervals[i-1]<break3){
				bullettypeonset[i]=2;
				continue;
			}
			bullettypeonset[i]=3;
		}*/

		musicinfo.onsetbysecond = onsetbysecond;
		musicinfo.onsetintervals = onsetintervals;

	}

	public void processMusicSegment (double[][] grid)
	
	{

		double[] segmentinterval = grid [0];
		double[] segmentnumber = grid [1];

		int indexinterval = segmentnumber.Length-1;
		int indexonset = musicinfo.onsetbysecond.Length-1;
		int[] bullettypeonset = new int[musicinfo.onsetbysecond.Length];
		List<int> bullettypes =  new List<int>();
		bullettypes.Add((int)segmentnumber[indexinterval]);
		musicinfo.maxtype = (int) segmentnumber [indexinterval];
		while (indexonset>=0) {
			if(musicinfo.onsetbysecond[indexonset]>=segmentinterval[indexinterval]){
				bullettypeonset[indexonset] = (int) segmentnumber[indexinterval];
			}
			else{
				indexinterval--;
				bullettypeonset[indexonset] = (int) segmentnumber[indexinterval];
				if(segmentnumber[indexinterval]>musicinfo.maxtype)
					musicinfo.maxtype= (int)segmentnumber[indexinterval];
				if(!bullettypes.Contains((int)segmentnumber[indexinterval]))
					bullettypes.Add((int)segmentnumber[indexinterval]);
			}
			indexonset--;
		}

		musicinfo.bullettypebyonset = bullettypeonset;
		musicinfo.patterntypes = bullettypes;
	}

	public void processMusicBeat (double[][] grid){

		double[] beatpersecond = grid [0];
		double[] BPM = grid [1];
		double sum = 0;
		int count = 0;
		foreach (double beattime in BPM){
			if(beattime != 0){
				sum = sum + beattime;
				count ++;
			}
		}
		double average = sum / count;
		musicinfo.BPM = average;
		musicinfo.BPMtimes = beatpersecond;
	}
	public void processMusicPitch(double[][] grid){
		double[] pitchtimes = grid [0];
		double[] pitchvalues = grid [1];

		double[] pitchbyonset = new double[musicinfo.onsetbysecond.Length];
		int j=0;
		for (int i=0; i<musicinfo.onsetbysecond.Length; i++) {
			while(pitchtimes[j]<musicinfo.onsetbysecond[i]){j++;}
			if(pitchtimes[j]==musicinfo.onsetbysecond[i]){
				pitchbyonset[i]=pitchvalues[j];
			}
			else{
				pitchbyonset[i]=pitchvalues[j-1];
			}
		}
		musicinfo.pitchbyonset = pitchbyonset;


	}

}
