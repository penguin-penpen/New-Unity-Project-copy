using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	public Plant apple;

	// Use this for initialization
	void Start () {
//		游戏开始初始化Game实例
		SaveLoad.Load();
//		List<Game> 
		Game.current = new Game ();
//		if (File.Exists (Application.persistentDataPath + "/savedGames.gd")) {
//			
//		}
		Game.current = SaveLoad.savedGames [15];
		print (SaveLoad.savedGames.Count);
		print("current");
//
//		for (int i = 0; i < 840; i++) {
//			Game.current = SaveLoad.savedGames [0];
//			string name = Game.current.objectNames [i];
//			string positionName = "PlantPosition (" + name + ")";
//			Vector3 pos = GameObject.Find (positionName).transform.position;
//
//			if (name == "apple") {
//				GameObject.Instantiate (apple, pos, Quaternion.identity);
//			}
//		}


	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.A)) {
//			print ("save");
			SaveLoad.Save ();
		}
		if (Input.GetKey (KeyCode.B)) {
//			print ("loading...");
//			List<string> ls = SaveLoad.gameNames [0];
//			foreach (string name in ls) {
//				if (name != null) {
//					print (name);
//					print ("this is the object name!");
//				}
//			}

			foreach (string name in Game.current.objectNames) {
				if (name != null) {
					print (name);
					print(Game.current.objectNames.IndexOf(name));
				}
			}
//			print (Game.current.test);
		}

		if (Input.GetKey (KeyCode.I)) {
			//遍历所有PlantPosition，实例化object
			for (int i = 1; i <= PlantPosition.positionCount; i++) {
				if (Game.current.objectNames [i] == "apple") {
					string plantPosName = "PlantPosition (" + i + ")";
					GameObject pos = GameObject.Find (plantPosName);
					Instantiate (apple, pos.transform.position, Quaternion.identity);
				}
			}
		}
			
	}
}
