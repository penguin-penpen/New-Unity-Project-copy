/*
 * 鼠标点击产生豌豆射手
 * zombieEntered状态转换
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

public class PlantPosition : MonoBehaviour {
	public GameObject spawner;
//	private int totalPlants = 0;
//	private bool zombieEntered = false;

	//position总数
	public static int positionCount = 840;

	//位置编号
	public static int positionIndex;

	// Use this for initialization
	void Start () {
//		plantSpawner = (GameObject)GameObject.Find("PlantSpawner");
		spawner = (GameObject)GameObject.Find("Spawner");


	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown(){
		spawner.GetComponent<Spawner>().SpawnHere(transform.position);
		//每次放置物体时，更新存放物体名称和位置的两个列表

//		正则提取位置编号
		MatchCollection mc = Regex.Matches(this.name, "[0-9]+");
//		positionIndex = int.Parse(new string(this.name.Split(' ')[1].Skip(1).TakeWhile(char.IsDigit).ToArray()));
		positionIndex = int.Parse(mc[0].ToString());
		//更新
		print(positionIndex);
		Game.current.objectNames [positionIndex] = objectChoice.objectName;
//		Game.current.objectPositions [positionIndex] = this.transform.position;
//		print ("name saved is");
//		print (Game.current.objectNames [positionIndex]);
//		Game.objectPositions [positionIndex] = this.transform.position;
//			if(result == true){
//				totalPlants = totalPlants + 1;
//			}
//		}
	}
	
}
