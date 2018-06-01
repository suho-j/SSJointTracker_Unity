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
        
        //NECK.transform.rotation = Quaternion.Euler(0,0,-(float)(dt.Rows[5].ItemArray[2]));
        //RSHOULDER.transform.rotation.eulerAngles


        //RSHOULDER.transform.position = new Vector3((float)-0.0554+(float)(dt.Rows[2].ItemArray[1]),(float)-4.7463+(float)(dt.Rows[2].ItemArray[9]),(float)-9.9602+(float)(dt.Rows[2].ItemArray[10]));///121
        //RELBOW.transform.rotation = Quaternion.Euler((float)dt.Rows[2].ItemArray[3], (float)dt.Rows[2].ItemArray[2], (float)(dt.Rows[2].ItemArray[1]));//166
        //RWRIST.transform.position = new Vector3((float)-0.1624+(float)(dt.Rows[2].ItemArray[3]),(float)-6.6064+(float)(dt.Rows[2].ItemArray[15]),(float)1.72681+(float)(dt.Rows[2].ItemArray[16]));///121

        //for (int i = 0; i < 40; i++)
        //{
        //    RELBOW.transform.rotation = Quaternion.Euler((float)(dt.Rows[i].ItemArray[1]), (float)(dt.Rows[i].ItemArray[2]), (float)(dt.Rows[i].ItemArray[3]));
        //    Debug.Log(dt.Rows[i].ItemArray[1]);
        //    Debug.Log(dt.Rows[i].ItemArray[2]);
        //    Debug.Log(dt.Rows[i].ItemArray[3]);
        //}


        //RSHOULDER.transform.rotation = Quaternion.Euler(0,0,(float)(dt.Rows[5].ItemArray[3]));///121
        //RELBOW.transform.rotation = Quaternion.Euler((float)dt.Rows[2].ItemArray[3],(float)dt.Rows[2].ItemArray[2],(float)(dt.Rows[2].ItemArray[1]));//166
        //LSHOULDER.transform.rotation = Quaternion.Euler(0,0,(float)(dt.Rows[5].ItemArray[5]));//126
        //LELBOW.transform.rotation = Quaternion.Euler(0,0,(float)(dt.Rows[5].ItemArray[6]));//173

        /*
		for (int i = 0; i < 12 ; i++) {
			Debug.Log (dt.Rows[0].ItemArray[i]); // first pose in first row
			//dt.Rows[0].ItemArray[3]
		}*/

        
        

    
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
            RELBOW.transform.rotation = Quaternion.Euler((float)(dt.Rows[i].ItemArray[2]), (float)(dt.Rows[i].ItemArray[2])*(-1)+270, (float)(dt.Rows[i].ItemArray[3])*(-1)+180);
            //Debug.Log(dt.Rows[i].ItemArray[1]);
            //Debug.Log(dt.Rows[i].ItemArray[2]);
            //Debug.Log(dt.Rows[i].ItemArray[3]);
            i++;
            //if (i > dt.Rows) i = 0;

            //RElbow_called();
            FPS = (int)(1f / Time.deltaTime); //1초당 프레임
                                              // dt.Rows[0].ItemArray[3]
                                              // 각도 구하기, x: 앞뒤, y: 제자리회전, z: 좌우


            //RELBOW.transform.rotation = Quaternion.Euler((float)dt.Rows[2].ItemArray[3], (float)dt.Rows[2].ItemArray[2], (float)(dt.Rows[2].ItemArray[1]));//166
            //LELBOW.transform.rotation = Quaternion.Euler(0,90,-90); //팔직각

            //RHIP.transform.rotation = Quaternion.Euler(0,0,0);
            //LHIP.transform.rotation = Quaternion.Euler(0,0,0);
        }
        catch
        {
            Debug.Log("catch");
            i = 0;
        }


    }



}