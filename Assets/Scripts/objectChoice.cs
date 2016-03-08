using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class objectChoice : MonoBehaviour {
	//objectName与prefab名称相同
	public static string objectName;
	private GameObject spawner;
	// Use this for initialization
	void Start () {
		spawner = (GameObject)GameObject.Find ("Spawner");
	}
	
	// Update is called once per frame
	void Update()
	{ 
		
	}

	void OnMouseDown(){
//		print ("mouse down");
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hitInfo;
		if(Physics.Raycast(ray,out hitInfo))
		{
			GameObject gameObj = hitInfo.transform.gameObject;
			objectName = gameObj.name;
			print (objectName);
			spawner.GetComponent<Spawner>().setPrefab(objectName);
		}
	}
}
