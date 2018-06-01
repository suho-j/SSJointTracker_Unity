using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;     //C#의 데이터 테이블 때문에 사용

public class RotationFrom_RightShoulder : MonoBehaviour {
	public GameObject RightArmMotion, RightForeArmMotion, RightHandMotion;
	public GameObject LeftArmMotion, LeftForeArmMotion, LeftHandMotion;
	public GameObject RightUpLegMotion, RightLegMotion, RightFootMotion;
	public GameObject LeftUpLegMotion, LeftLegMotion, LeftFootMotion;
	public GameObject SpineMotion, HeadMotion, NeckMotion;

	public Transform rotator;

	dbmysql mysqlDB = new dbmysql ();

	// Use this for initialization
	void Start () {
		DataTable dt = mysqlDB.selsql ("SELECT * FROM jointxyz");

		RightArmMotion = GameObject.FindWithTag ("Right Arm");
		RightForeArmMotion = GameObject.FindWithTag ("Right Fore Arm");
		RightHandMotion = GameObject.FindWithTag ("Right Hand");

		LeftArmMotion = GameObject.FindWithTag ("Left Arm");
		LeftForeArmMotion = GameObject.FindWithTag ("Left Fore Arm");
		LeftHandMotion = GameObject.FindWithTag ("Left Hand");

		RightUpLegMotion = GameObject.FindWithTag ("Right Up Leg");
		RightLegMotion = GameObject.FindWithTag ("Right Leg");
		RightFootMotion = GameObject.FindWithTag ("Right Foot");

		LeftUpLegMotion = GameObject.FindWithTag ("Left Up Leg");
		LeftLegMotion = GameObject.FindWithTag ("Left Leg");
		LeftFootMotion = GameObject.FindWithTag ("Left Foot");

		SpineMotion = GameObject.FindWithTag ("Spine");
		HeadMotion = GameObject.FindWithTag ("Head");
		NeckMotion = GameObject.FindWithTag ("Neck");

		//rotator = transform;
	}

	// Update is called once per frame
	void Update () {
		// rotation은 = 개념, rotate는 += 개념
		// 왼쪽 팔 y는 -가 앞으로 

		//RightArmMotion.transform.rotation = Quaternion.Euler (transform.eulerAngles.x, 45, RightArmMotion.transform.eulerAngles.x);
		//LeftArmMotion.transform.rotation = Quaternion.Euler (transform.eulerAngles.x, transform.eulerAngles.y, RightArmMotion.transform.eulerAngles.x);
		//RightArmMotion.transform.rotation = Quaternion.Euler (45, -30, RightArmMotion.transform.eulerAngles.x);
		LeftArmMotion.transform.rotation = Quaternion.Euler (transform.eulerAngles.x, 45, LeftArmMotion.transform.eulerAngles.x);
	}
}
