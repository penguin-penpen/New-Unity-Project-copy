using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class ChangeSpeed : MonoBehaviour {
	public float time_ = 2f;//持续时间
	public float Speed_Change = 0.1f;//改变后的速度值
	private bool temp = false;
	private float temp_speed;

	void OnTriggerEnter (Collider col){
		if (col.tag == "player") {
			temp = true;
		} else
			temp = false;

	}

	// Use this for initialization
	void Start () {
		temp_speed = Player.instance.move_speed;
	}

	// Update is called once per frame
	void FixedUpdate () {

		if (time_ < 0) {
			Player.instance.SpeedUpdate(temp_speed);
		}

		if (temp ==true && time_ > 0) {
			time_ -= Time.deltaTime;
			this.gameObject.GetComponent<Renderer> ().enabled = false;
			Player.instance.SpeedUpdate (Speed_Change);
		} 
	}

}
