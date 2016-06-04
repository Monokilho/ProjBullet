using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LuaInterface;

public class TypeMethods
{
	private TypeProperty typeproperty;

	public TypeMethods(TypeProperty typeproperty){
		this.typeproperty = typeproperty;
	}

	public double getValueAt (int index){
		if (index == 273)
			Debug.Log ("bla");
		double pitch = typeproperty.pitchvalues[index];

		return pitch;
	}

	public double getMaxPitch(){

		List<double> pitchList = typeproperty.pitchvalues;
		double max = 0.0;

		for (int i=0; i < pitchList.Count; i++) {
			if (pitchList[i] >= max)
				max = pitchList[i];
		}

		return max;

	}
}

