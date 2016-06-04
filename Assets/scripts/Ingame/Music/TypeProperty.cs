using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TypeProperty
{

	public int segmentnumber;
	public double averageinterval;
	public List<int> countonsetpergroup;
	public List<double> onsettimes;
	public List<double> pitchvalues;

	public TypeProperty(int type){
		segmentnumber = type;
	}


}
