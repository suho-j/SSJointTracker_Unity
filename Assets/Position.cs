using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour {
    public GameObject RightArmMotion, RightForeArmMotion, RightHandMotion;
    public GameObject LeftArmMotion, LeftForeArmMotion, LeftHandMotion;
    public GameObject RightUpLegMotion, RightLegMotion, RightFootMotion;
    public GameObject LeftUpLegMotion, LeftLegMotion, LeftFootMotion;
    public GameObject SpineMotion, HeadMotion, NeckMotion;
    public GameObject All;

    public Quaternion rotation = Quaternion.identity;
    public Quaternion rotation_init = Quaternion.identity;
    float speed = 10 * Time.deltaTime;

    // Use this for initialization
    void Start () {
        RightArmMotion = GameObject.FindWithTag("Right Arm");
        RightForeArmMotion = GameObject.FindWithTag("Right Fore Arm");
        RightHandMotion = GameObject.FindWithTag("Right Hand");

        LeftArmMotion = GameObject.FindWithTag("Left Arm");
        LeftForeArmMotion = GameObject.FindWithTag("Left Fore Arm");
        LeftHandMotion = GameObject.FindWithTag("Left Hand");

        RightUpLegMotion = GameObject.FindWithTag("Right Up Leg");
        RightLegMotion = GameObject.FindWithTag("Right Leg");
        RightFootMotion = GameObject.FindWithTag("Right Foot");

        LeftUpLegMotion = GameObject.FindWithTag("Left Up Leg");
        LeftLegMotion = GameObject.FindWithTag("Left Leg");
        LeftFootMotion = GameObject.FindWithTag("Left Foot");

        SpineMotion = GameObject.FindWithTag("Spine");
        HeadMotion = GameObject.FindWithTag("Head");
        NeckMotion = GameObject.FindWithTag("Neck");

        All = GameObject.FindWithTag("All");

        //rotation.eulerAngles = new Vector3(0, 0.0f, 0.0f);
        //rotation_init.eulerAngles = new Vector3(0, 0, 0);
        //RightForeArmMotion.transform.rotation = Quaternion.identity;
        //All.transform.rotation = rotation;
    }

    // Update is called once per frame
    float x = 60;
    void Update () {
        //SpineMotion.transform.position = new Vector3(0, 0, 0);
        //RightForeArmMotion.transform.position = new Vector3(1 / Mathf.Sqrt(3), 1 / Mathf.Sqrt(3), 1 / Mathf.Sqrt(3));

        //HeadMotion.transform.rotation = Quaternion.Euler(new Vector3(-0.04748185, -0.194622, 0.129269));

        // 계속 회전
        //RightForeArmMotion.transform.rotation = RightForeArmMotion.transform.rotation * rotation;
        //RightForeArmMotion.transform.rotation = rotation;

        //RightForeArmMotion.transform.eulerAngles = new Vector3(0, 90, 0);

        // 계속회전
        //x += Time.deltaTime * 10;
        RightForeArmMotion.transform.localRotation = Quaternion.Euler(45f, 45f, 0);
        //RightForeArmMotion.transform.rotation *= rotation_init;
        //RightForeArmMotion.transform.rotation *= rotation;


    }
}
