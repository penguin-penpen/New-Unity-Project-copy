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
		Game.current = SaveLoad.savedGames [-1];
//		print("current");
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
				}
			}
//			print (Game.current.test);
		}
			
	}
}
