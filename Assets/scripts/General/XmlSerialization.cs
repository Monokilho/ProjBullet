using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.IO;
using System;

public static class XmlSerialization {
	public static bool Serialize (string path, System.Object obj){
		try{
		XmlSerializer serializer = new XmlSerializer(obj.GetType());
		FileStream stream = new FileStream(path, FileMode.Create);
		serializer.Serialize(stream, obj);
		stream.Close();
		}
		catch (Exception e){
			Debug.Log ("Error at saving XML file of type:" + obj.GetType()  +"\n" + e);
			return false;
	//missing ingame console warning
		}
		return true;
	}

	public static object Deserialize (string path, System.Object obj){
		try{
		XmlSerializer serializer = new XmlSerializer(obj.GetType());
		FileStream stream = new FileStream(path, FileMode.Open);
		obj = serializer.Deserialize(stream);
		stream.Close();
		}
		catch (Exception e){
			Debug.Log ("Error at loading XML file of type:" + obj.GetType() +"\n" + e);
			return null;
		}
		return obj;
	}
}
