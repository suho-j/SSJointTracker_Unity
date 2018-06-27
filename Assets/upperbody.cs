using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;

public class upperbody : MonoBehaviour {
    public GameObject NOSE, NECK, RSHOULDER, RELBOW, RWRIST, LSHOULDER, LELBOW, LWRIST;
    public GameObject RHIP, RKNEE, RANKLE, LHIP, LKNEE, LANKLE;

    public int FPS { get; private set; }
    dbmysql mysqlDB = new dbmysql();
    public static DataTable dt = new DataTable();
    public int i = 0;

    // Use this for initialization
    void Start()
    {
        dt = mysqlDB.selsql("SELECT * FROM upperbodyangle");
        RSHOULDER = GameObject.FindWithTag("Right Arm");
        RELBOW = GameObject.FindWithTag("Right Fore Arm");
        RWRIST = GameObject.FindWithTag("Right Hand");

        LSHOULDER = GameObject.FindWithTag("Left Arm");
        LELBOW = GameObject.FindWithTag("Left Fore Arm");
        LWRIST = GameObject.FindWithTag("Left Hand");

        RHIP = GameObject.FindWithTag("Right Up Leg");
        RKNEE = GameObject.FindWithTag("Right Leg");
        RANKLE = GameObject.FindWithTag("Right Foot");

        LHIP = GameObject.FindWithTag("Left Up Leg");
        LKNEE = GameObject.FindWithTag("Left Leg");
        LANKLE = GameObject.FindWithTag("Left Foot");

        //SpineMotion = GameObject.FindWithTag("Spine");
        //HeadMotion = GameObject.FindWithTag("Head");
        //NeckMotion = GameObject.FindWithTag("Neck");

        //rotator = transform;
    }
    // Update is called once per frame
    void Update () {
        try
        {
            //RSHOULDER.transform.localRotation = Quaternion.Euler((float)0.01f, (float)(dt.Rows[i].ItemArray[1]), (float)(dt.Rows[i].ItemArray[2]));
            RELBOW.transform.localRotation = Quaternion.Euler((float)0.01f, (float)(dt.Rows[i].ItemArray[3]), (float)(dt.Rows[i].ItemArray[4])*(-1));
            //LSHOULDER.transform.localRotation = Quaternion.Euler((float)0.01f, (float)(dt.Rows[i].ItemArray[5]), (float)(dt.Rows[i].ItemArray[6]));
            //LELBOW.transform.localRotation = Quaternion.Euler((float)0.01f, (float)(dt.Rows[i].ItemArray[7])*(-1), (float)(dt.Rows[i].ItemArray[8])*(-1));
            i++;
        }
        catch
        {
            Debug.Log("End");
            i = 0;
        }

    }
}
