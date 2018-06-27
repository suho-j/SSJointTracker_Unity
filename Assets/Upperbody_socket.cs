using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class Upperbody_socket : MonoBehaviour {

    public GameObject NOSE, NECK, RSHOULDER, RELBOW, RWRIST, LSHOULDER, LELBOW, LWRIST;
    public GameObject RHIP, RKNEE, RANKLE, LHIP, LKNEE, LANKLE;
    public GameObject PANEL;

    //width x height x RGB(3) = 921600, 임의 할당
    byte[] readBuffer = new byte[921600];
    byte[] readBuffer2 = new byte[100];
    int angleY = 90;
    int angleZ = 0;

    TcpListener server;

    // Use this for initialization
    void Start () {
        PANEL = GameObject.FindWithTag("PANEL");
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

        //StartCoroutine(move());
        //Quaternion Right = Quaternion.identity;
        //Right.eulerAngles = new Vector3(0, 170f, 0);
        //RELBOW.transform.localRotation = Quaternion.Slerp(RELBOW.transform.localRotation, Right, 1f);

    }
    IEnumerator move()
    {
        Quaternion Right = Quaternion.identity;
        Right.eulerAngles = new Vector3(0, 150f, 0);
        RELBOW.transform.localRotation = Quaternion.Slerp(RELBOW.transform.localRotation, Right, 1.0f);

        while(true)
        {
            yield return new WaitForSeconds(0.1f);
            if(RELBOW.transform.localRotation.y <= 150)
            {
                break;
            }
        }
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

        // Socket Start 
        CreateSocket();
        Debug.Log("TCP LIsten Start");

        client = server.AcceptTcpClient();
        

        stream = client.GetStream();
        byteRead = stream.Read(readBuffer2, 0, readBuffer2.Length);
        Debug.Log(readBuffer2);
        int.TryParse(ByteToString(readBuffer2), out angleY);
        stream.Write(readBuffer2, 0, byteRead);
        Debug.Log("angleY");
        Debug.Log(angleY);

        stream = client.GetStream();
        byteRead = stream.Read(readBuffer2, 0, readBuffer2.Length);
        int.TryParse(ByteToString(readBuffer2), out angleZ);
        stream.Write(readBuffer2, 0, byteRead);
        Debug.Log("angleZ");
        Debug.Log(angleZ);


        stream = client.GetStream();
        //readbuffer, byteRead: 전달받은 byte length
        byteRead = stream.Read(readBuffer, 0, readBuffer.Length);
        //메시지 전달
        stream.Write(readBuffer, 0, byteRead);

        //소켓통신 종료
        client.Close();
        server.Stop();
        return readBuffer;
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
        Renderer rend = PANEL.GetComponentInChildren<Renderer>();
        // assuming the first available WebCam is desired
        Texture2D tex = null;

        //height, width 640, 480.  필요시 변경 필요.
        tex = new Texture2D(640, 480, TextureFormat.RGB24, false);
        tex.LoadImage(readBuffer);
        rend.material.mainTexture = tex;

        //메모리 할당 해제
        Resources.UnloadUnusedAssets();

    }
    void applyangle()
    {
        //RELBOW.transform.localRotation = Quaternion.Euler((float)0.01f, (float)angleY, (float)angleZ*(-1));
        
        Debug.Log(angleY);
        Debug.Log(angleZ);
    }

    void checkslerp()
    {
        Quaternion a = Quaternion.Euler((float)0.01f, (float)0, (float)0);
        Quaternion b = Quaternion.Euler((float)0.01f, (float)180, (float)0);
        
    }
    // Update is called once per frame
    void Update () {
        Quaternion Right = Quaternion.identity;
        Right.eulerAngles = new Vector3(0, 150f, 0);
        RELBOW.transform.localRotation = Quaternion.Slerp(RSHOULDER.transform.localRotation, Right, Time.deltaTime * 0.5f);
        //RELBOW.transform.localRotation = Quaternion.Euler((float)0.01f, (float)angleY, (float)angleZ * (-1));
        //checkslerp();
        //TCPListen();
        //readBuffer - 전역변수, 데이터가 있을경우만 ShowCam을 호출
        if (readBuffer != null)
        {
            

            //ShowCam(readBuffer);
            //applyangle();
        }
    }
}
