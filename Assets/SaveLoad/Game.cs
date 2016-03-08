/*
 * 仅储存物体的name
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[System.Serializable]
public class Game{ //don't need ": Monobehaviour" because we are not attaching it to a game object

	public static Game current;
	//用于存放物体位置
	public List<Vector3> objectPositions;
	//objectStrings 用于存放对应position的物体名称
	public List<string> objectNames;
	//test string
	public string test;

//	public static void setName(int index, string name){
//		objectNames [index] = name;
//	}
//
//	public static void setPosition(int index, Vector3 position){
//		objectPositions [index] = position;
//	}

	public Game(){
		//新建列表以plantposition的个数多一个初始化，因为不使用index 0
		objectNames = new List<string>(PlantPosition.positionCount + 1);
		objectPositions = new List<Vector3>(PlantPosition.positionCount + 1);
		test = "load success.";
	}
}
