using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;     //C#의 데이터 테이블 때문에 사용
using MySql.Data;     //MYSQL함수들을 불러오기 위해서 사용
using MySql.Data.MySqlClient;    //클라이언트 기능을사용하기 위해서 사용

//clsMysqlDB

public class dbmysql : MonoBehaviour
{

	MySqlConnection sqlconn = null;
	public string sqlDBip = "192.168.0.41";
	public string sqlDBname = "o2";
	public string sqlDBid = "kgm";
	public string sqlDBpw = "123123";

	public void sqlConnect()
	{
		//DB정보 입력
		string sqlDatabase = "Server=" + sqlDBip + ";Database=" + sqlDBname + ";UserId=" + sqlDBid + ";Password=" + sqlDBpw + "";

		//접속 확인하기
		try
		{
			sqlconn = new MySqlConnection(sqlDatabase);
			sqlconn.Open();
			Debug.Log("SQL의 접속 상태 : " + sqlconn.State); //접속이 되면 OPEN이라고 나타남
		}
		catch (System.Exception msg)
		{
			Debug.Log(msg); //기타다른오류가 나타나면 오류에 대한 내용이 나타남
		}
	}

	public void sqldisConnect()
	{
		sqlconn.Close();
		Debug.Log("SQL의 접속 상태 : " + sqlconn.State); //접속이 끊기면 Close가 나타남 
	}

	// INSERT, UPDATE 문
	public void sqlcmdall(string allcmd) //함수를 불러올때 명령어에 대한 String을 인자로 받아옴
	{
		sqlConnect(); //접속

		MySqlCommand dbcmd = new MySqlCommand(allcmd, sqlconn); //명령어를 커맨드에 입력
		dbcmd.ExecuteNonQuery(); //명령어를 SQL에 보냄

		sqldisConnect(); //접속해제
	}

	// SELECT 문
	public DataTable selsql(string sqlcmd)  //리턴 형식을 DataTable로 선언함
	{
		DataTable dt = new DataTable(); //데이터 테이블을 선언함

		sqlConnect();

		MySqlDataAdapter adapter =  new MySqlDataAdapter(sqlcmd, sqlconn);
		adapter.Fill(dt); //데이터 테이블에  채워넣기를함
		sqldisConnect();

		return dt; //데이터 테이블을 리턴함
	}

	// Use this for initialization
	void Start()
	{
		
		// first Avatar Pose
		dbmysql mysqlDB = new dbmysql ();
		DataTable dt = mysqlDB.selsql ("SELECT * FROM elbow_angle");
		// mysqlDB.sqlcmdall ("INSERT 또는 업데이트 ");

		for (int i = 0; i < 12 ; i++) {
			Debug.Log (dt.Rows[0].ItemArray[i]); // first pose in first row
            //dt.Rows[0].ItemArray[3]
		}
	}

	// Update is called once per frame
	void Update () {
		// if Correction is upper 90%, we should change other pose in Second row in DB.
		/*FrameTiming
		// Second Avatar Pose
		if() {
			dbmysql mysqlDB = new dbmysql ();
			DataTable dt = mysqlDB.selsql ("SELECT * FROM anglexyz");
			// mysqlDB.sqlcmdall ("INSERT 또는 업데이트 ");
			for (int i = 0; i < 34; i++) {
				Debug.Log (dt.Rows [1].ItemArray [i]); // seconde pose in second row
			}
		}*/
	}
}