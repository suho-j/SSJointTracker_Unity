using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;


public class serverYZ : MonoBehaviour
{
    //width x height x RGB(3) = 921600, 임의 할당
    byte[] readBuffer = new byte[921600];
    byte[] readBuffer2 = new byte[100];

    TcpListener server;



    public GameObject NOSE, NECK, RSHOULDER, RELBOW, RWRIST, LSHOULDER, LELBOW, LWRIST;
    public GameObject RHIP, RKNEE, RANKLE, LHIP, LKNEE, LANKLE;



    void Start()
    {
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

    }
    // TCP/IP 통신 Start
    void CreateSocket()
    {
        server = new TcpListener(IPAddress.Any, 56789);
        try
        {
            server.Start();
            //Debug.Log("server started ...");
        }
        catch (Exception ex)
        {
            Debug.Log(ex.ToString());

        }
    }



    // 소켓 통신, byte데이터 받고 통신 종료. 
    byte[] TCPListen()
    {

        TcpClient client = default(TcpClient);
        NetworkStream stream;

        int byteRead;
        string msg;

        // Socket Start 
        CreateSocket();
        Debug.Log("TCP LIsten Start");

        client = server.AcceptTcpClient();
        int i = 0;
        stream = client.GetStream();
        //readbuffer, byteRead: 전달받은 byte length
        byteRead = stream.Read(readBuffer2, 0, readBuffer2.Length);

        msg = ByteToString(readBuffer2);
        int s = 0;
        int s2 = 0;
        //s = BitConverter.ToInt16(readBuffer2, 0);
        Debug.Log(msg);
        int.TryParse(msg, out s);
        Debug.Log(s);
        RELBOW.transform.localRotation = Quaternion.Euler((float)0.01f, (float)(s), (float)(s2));
        //string[] split_text = new string[2];
        //split_text = msg.Split('_');
        //Debug.Log(split_text[0]);
        //Debug.Log(split_text[1]);
        //Debug.Log(split_text[2]);

        msg = Encoding.ASCII.GetString(readBuffer2, 0, byteRead);
        Debug.Log(msg);
        i++;
        //메시지 전달
        stream.Write(readBuffer2, 0, byteRead);

        //소켓통신 종료
        client.Close();
        server.Stop();
        return readBuffer2;
    }

    string ByteToString(byte[] strByte)
    {
        string str = Encoding.ASCII.GetString(strByte);
        return str;
    }

    byte[] StringToByte(string str)
    {
        byte[] strByte = Encoding.UTF8.GetBytes(str);
        return strByte;
    }

    void ShowCam(byte[] readBuffer)
    {
        //Debug.Log("showCam is called");
        WebCamDevice[] devices = WebCamTexture.devices;

        // for debugging purposes, prints available devices to the console
        for (int i = 0; i < devices.Length; i++)
        {
            //print("Webcam available: " + devices[i].name);
        }
        Renderer rend = this.GetComponentInChildren<Renderer>();
        // assuming the first available WebCam is desired
        Texture2D tex = null;

        //height, width 640, 480.  필요시 변경 필요.
        tex = new Texture2D(640, 480, TextureFormat.RGB24, false);
        tex.LoadImage(readBuffer);
        rend.material.mainTexture = tex;

        //메모리 할당 해제
        Resources.UnloadUnusedAssets();

    }
    // Update is called once per frame
    void Update()
    {
        string text = "text";
        string text2;
        string[] split_text = new string[2];
        byte[] by;
        TCPListen();
        //readBuffer - 전역변수, 데이터가 있을경우만 ShowCam을 호출

        //text = ','+999.ToString()+','+999.ToString();
        //Debug.Log(text);
        //by = StringToByte(text);
        //Debug.Log(by);
        //text2 = ByteToString(by);
        //Debug.Log(text2);
        //split_text = text2.Split(',');
        //Debug.Log(split_text[0]);
        //Debug.Log(split_text[1]);
        //Debug.Log(split_text[2]);
        if (readBuffer != null)
        {
            text = ByteToString(readBuffer2);
            Debug.Log(text);
            split_text = text.Split('_');
            //readBuffer = split_text[0];
            //RELBOW.transform.localRotation = Quaternion.Euler((float)0.01f, (float)(Convert.ToInt32(split_text[1])), (float)(Convert.ToInt16(split_text[2])));
            //ShowCam(readBuffer);

            int ss;
            int.TryParse(split_text[0],out ss);
            Debug.Log(ss);
            int sss;
            int.TryParse(split_text[1], out sss);
            Debug.Log(sss);
            int ssss;
            int.TryParse(split_text[2], out ssss);
            Debug.Log(ssss);
            //Debug.Log(split_text[0]);
            //Debug.Log(split_text[1]);
            //Debug.Log(split_text[2]);
        }
    }


}


