using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private int a = 0; 
	private float jump_timeMax = 0.3f; //最大可持续跳跃时间
	private float jump_time; //跳跃时间
	public 	float Yspeed = 10f;       // 向上跳跃速度
	public float move_speed = 0.5f; //移动速度
	public static Player instance;     //gengxin 

	void Awake(){                    //gengxin
		instance = this;
	}

	public void SpeedUpdate(float temp){
		move_speed = temp;
	}

	void OnCollisionEnter(){
		jump_time = jump_timeMax; //重置跳跃时间
		a = 0; //重置跳跃次数
	}


	void jump(){
		this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,Yspeed,0);
	}

	void Start () {
		Physics.gravity = new Vector3 (0, -30f, 0); //重力大小，影响下落速度
	}

	void Update () {
		/*		if (Input.GetKeyDown (KeyCode.UpArrow) && a < 2 ) {		
		    Yspeed = 30;
			this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,Yspeed,0);
			a++;
     	}
*/
		//跳跃

		if (Input.GetKey (KeyCode.UpArrow) && a<2 && jump_time > 0) {
			jump();
			jump_time -=Time.deltaTime;
		}


		if (Input.GetKeyUp (KeyCode.UpArrow)) {
			jump_time = jump_timeMax;
			a++;
		}


		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Translate( -move_speed,0,0);
		}

		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Translate( move_speed,0,0);
		}

	}

	void OnCollisionEnter(Collider a){
		print ("collide!!!");
		if(a.gameObject.tag=="re"){
			this.gameObject.transform.position.Set (0.3f,4.9f,-0.06f);
			//			GameManager._intance.GameState = GameManager.GAMESTATE_END;//改变游戏状态
		}
	}

}










