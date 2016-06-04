using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MusicInfoScript{
	public double[] onsetbysecond;
	public double[] onsetintervals;
	public int[] bullettypebyonset;
	public double BPM;
	public double[] BPMtimes;
	public double[] pitchbyonset;
	public List<int> patterntypes;
	public int maxtype;
	public List<TypeProperty> propertiesList;


	public void calculateValues ()
	{
		propertiesList = new List<TypeProperty> ();
		for(int i =0;i<patterntypes.Count;i++) {
			propertiesList.Add(new TypeProperty(patterntypes[i]));
			calculateOnsetdata(propertiesList[i]);
			divideonsetandpitch(propertiesList[i]);
		}
	}

	void calculateOnsetdata (TypeProperty property){
		int type = property.segmentnumber;
		List<int> countonsetpergroup = new List<int>();
		double auxsum = 0;
		double auxcount = 0;
		List<double> auxonsettimes = new List<double> ();
		List<double> onsettimes = new List<double> ();
		for (int i=0; i<onsetbysecond.Length; i++) {
			if(bullettypebyonset[i] == type){
				auxonsettimes.Add(onsetbysecond[i]);
				onsettimes.Add(onsetbysecond[i]);
			}
			else{
				if(auxonsettimes.Count > 1){
					countonsetpergroup.Add(auxonsettimes.Count);
					auxcount=auxcount + auxonsettimes.Count-1;
					for(int j=1;j<auxonsettimes.Count;j++){
						auxsum=auxsum+(auxonsettimes[j]-auxonsettimes[j-1]);
					}
					auxonsettimes.Clear();
				}
			}
		}
		if(auxonsettimes.Count > 1){
			countonsetpergroup.Add(auxonsettimes.Count);
			auxcount=auxcount + auxonsettimes.Count-1;
			for(int j=1;j<auxonsettimes.Count;j++){
				if(auxonsettimes[j]!=0)
				auxsum=auxsum+(auxonsettimes[j]-auxonsettimes[j-1]);
			}
			auxonsettimes.Clear();
		}
		double average = auxsum / auxcount;
		property.averageinterval = average;
		property.countonsetpergroup = countonsetpergroup;
	}

	void divideonsetandpitch (TypeProperty typeProperty)
	{
		int type = typeProperty.segmentnumber;
		List<double> onsetpergroup = new List<double>();
		List<double> pitchpergroup = new List<double>();
		for(int i=0;i<bullettypebyonset.Length;i++){
			if(bullettypebyonset[i]==type){
				onsetpergroup.Add(onsetbysecond[i]);
				pitchpergroup.Add(pitchbyonset[i]);
			}
	}
		typeProperty.onsettimes = onsetpergroup;
		typeProperty.pitchvalues = pitchpergroup;
}
}