using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Spawner : MonoBehaviour {
	public Plant prefab;
	public Plant apple;
	public Plant pineapple;
//	private static float timeDelay;
//	private static bool spawnAllowed;
//	public Slider timeSlider;
//	public AudioClip audio1;
	// Use this for initialization
	void Start () {
//		timeDelay = 0f;
//		spawnAllowed = false;
//		timeSlider.minValue = 0f;
//		timeSlider.maxValue = 3f;
	}
	
	// Update is called once per frame
	void Update () {
//		timeDelay += Time.deltaTime;
		
//		if(timeDelay > 3f){
//			spawnAllowed = true;
//			print (timeDelay);
//		}	
//		timeSlider.value = timeDelay;
	}
	
	public void SpawnHere(Vector3 position){
//		if(spawnAllowed == true){
//			spawnAllowed = false;
			Instantiate(prefab,position,Quaternion.identity);
//			timeDelay = 0f;
//			AudioSource.PlayClipAtPoint(audio1,transform.position);
//			return true;
		}
//		return false;
//	}
	
//	public static float getTimeDelay(){
//		return timeDelay;
//	}

	public void setPrefab(string name){
		if (name == "apple") {
			prefab = apple;
		} else if (name == "pineapple") {
			prefab = pineapple;
		}
	}
}
