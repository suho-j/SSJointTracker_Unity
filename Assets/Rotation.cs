using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;     //C#의 데이터 테이블 때문에 사용

public class Rotation : MonoBehaviour {
	public GameObject NOSE, NECK, RSHOULDER, RELBOW, RWRIST, LSHOULDER, LELBOW, LWRIST;
	public GameObject RHIP, RKNEE, RANKLE, LHIP, LKNEE, LANKLE;

	public int FPS { get; private set; }
	dbmysql mysqlDB = new dbmysql ();
    public static DataTable dt = new DataTable();
    public int i = 0;
    // Use this for initialization


    private void Awake()
    {
        dt = mysqlDB.selsql("SELECT * FROM relbow_angle2");
    
    }
    IEnumerator Sleep(float time)
    {
        print("example");
        print(Time.time);
        yield return new WaitForSeconds(time);
        print(Time.time);
    }
    // Update is called once per frame

    IEnumerator Wait()
    {
        yield return StartCoroutine(Sleep(1.0f));
    }
    void Update () {
        try
        {
            //Debug.Log(i);
            Wait();
            RELBOW.transform.localRotation = Quaternion.Euler((float)0.01f, (float)(dt.Rows[i].ItemArray[2]), (float)(dt.Rows[i].ItemArray[3]));
            //RELBOW.transform.localRotation = Quaternion.Euler((float)0.01f, (float)(dt.Rows[i].ItemArray[3]), (float)(dt.Rows[i].ItemArray[4]));
            //LSHOULDER.transform.localRotation = Quaternion.Euler((float)0.01f, (float)(dt.Rows[i].ItemArray[5]), (float)(dt.Rows[i].ItemArray[6]));
            //LELBOW.transform.localRotation = Quaternion.Euler((float)0.01f, (float)(dt.Rows[i].ItemArray[7]), (float)(dt.Rows[i].ItemArray[8]));
            i++;

        }
        catch
        {
            Debug.Log("catch");
            i = 0;
        }


    }



}