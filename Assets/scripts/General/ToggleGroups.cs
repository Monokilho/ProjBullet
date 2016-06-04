using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class ToggleGroups <T> where T : class {

	public bool AllowMultiple;
	List<Toggle> togglelist;
	List<T> multipleselects;
	T selectedobj;

	public ToggleGroups(bool multiple) {
		AllowMultiple = multiple;
		togglelist = new List<Toggle>();
		multipleselects = new List<T> ();
	}

	public void add(Toggle clickedtoggle, T selectedobj){
		if (AllowMultiple) {
			togglelist.Add (clickedtoggle);
			multipleselects.Add(selectedobj); 

		} 


		else {

			if(togglelist.Count!=0){
				togglelist[0].isOn=false;
			}
			togglelist.Add(clickedtoggle);
			this.selectedobj=selectedobj;
		}


	}
	
	public void remove(Toggle clickedtoggle, T selectedobj) {
		if (togglelist.Count != 0) {
			if (AllowMultiple)
				multipleselects.Remove(selectedobj);
			togglelist.Remove (clickedtoggle);
			this.selectedobj=null;
		
		
		}

	}

	public bool isEmpty(){
		return togglelist.Count==0;
	}

	public T getselect(){
		return selectedobj;
	}

	public List<T> getMultipleSelect(){
		return multipleselects;
	}

}
