using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;


public static class SaveLoad
{
	public static List<List<string>> gameNames = new List<List<string>> ();
	public static List<List<Vector3>> gamePositions = new List<List<Vector3>> ();

	public static List<Game> savedGames = new List<Game> ();
			
	//it's static so we can call it from anywhere
	public static void Save ()
	{
		Debug.Log ("saving...");
		SaveLoad.savedGames.Add (Game.current);
		gameNames.Add (Game.current.objectNames);
		gamePositions.Add (Game.current.objectPositions);
//		BinaryFormatter bf = new BinaryFormatter();
//		//Application.persistentDataPath is a string, so if you wanted you can put that into debug.log if you want to know where save games are located
//		Debug.Log(Application.persistentDataPath);
//		FileStream file = File.Create (Application.persistentDataPath + "/savedGames.gd"); //you can call it anything you want
//		bf.Serialize(file, SaveLoad.savedGames);
//		file.Close();

		//serialize name
		BinaryFormatter nameBf = new BinaryFormatter ();
		//Application.persistentDataPath is a string, so if you wanted you can put that into debug.log if you want to know where save games are located
		Debug.Log (Application.persistentDataPath);
		FileStream nameFile = File.Create (Application.persistentDataPath + "/Names.gd"); //you can call it anything you want
		nameBf.Serialize (nameFile, SaveLoad.gameNames);
		nameFile.Close ();


		//serialize positions(Vector3)
		BinaryFormatter posBf = new BinaryFormatter();
		// 1. Construct a SurrogateSelector object
		SurrogateSelector ss = new SurrogateSelector();
		Vector3SerializationSurrogate v3ss = new Vector3SerializationSurrogate();
		ss.AddSurrogate(typeof(Vector3), 
			new StreamingContext(StreamingContextStates.All), 
			v3ss);
		// 2. Have the formatter use our surrogate selector
		posBf.SurrogateSelector = ss;
		FileStream posFile = File.Create(Application.persistentDataPath + "/Positions.gd");
		posBf.Serialize (posFile, SaveLoad.gamePositions);
		posFile.Close ();

	}

	//load
	public static void Load ()
	{
		//load names
		if (File.Exists (Application.persistentDataPath + "/Names.gd")) {
			BinaryFormatter nameBf = new BinaryFormatter ();
			FileStream nameFile = File.Open (Application.persistentDataPath + "/Names.gd", FileMode.Open);
			SaveLoad.gameNames = (List<List<string>>)nameBf.Deserialize (nameFile);
			nameFile.Close ();
			Debug.Log ("name loaded successfully");
		}

		//load positions
		if (File.Exists (Application.persistentDataPath + "/Positions.gd")) {
			BinaryFormatter posBf = new BinaryFormatter ();
			SurrogateSelector ss = new SurrogateSelector();
			Vector3SerializationSurrogate v3ss = new Vector3SerializationSurrogate();
			ss.AddSurrogate(typeof(Vector3), 
				new StreamingContext(StreamingContextStates.All), 
				v3ss);
			FileStream nameFile = File.Open (Application.persistentDataPath + "/Names.gd", FileMode.Open);
			SaveLoad.gamePositions = (List<List<Vector3>>)posBf.Deserialize (nameFile);
			nameFile.Close ();
			Debug.Log ("positions loaded successfully");
		}

		//put data into Game.current
//		Game.current.objectNames = SaveLoad.gameNames;
//		Game.current.objectPositions = SaveLoad.gamePositions;
//		Debug.Log ("data's put into Game.current");
	}


	//serialization surrogate
	sealed class Vector3SerializationSurrogate : ISerializationSurrogate {

		// Method called to serialize a Vector3 object
		public void GetObjectData(System.Object obj,
			SerializationInfo info, StreamingContext context) {

			Vector3 v3 = (Vector3) obj;
			info.AddValue("x", v3.x);
			info.AddValue("y", v3.y);
			info.AddValue("z", v3.z);
			Debug.Log(v3);
		}

		// Method called to deserialize a Vector3 object
		public System.Object SetObjectData(System.Object obj,
			SerializationInfo info, StreamingContext context,
			ISurrogateSelector selector) {

			Vector3 v3 = (Vector3) obj;
			v3.x = (float)info.GetValue("x", typeof(float));
			v3.y = (float)info.GetValue("y", typeof(float));
			v3.z = (float)info.GetValue("z", typeof(float));
			obj = v3;
			return obj;   // Formatters ignore this return value //Seems to have been fixed!
		}
	}
}
