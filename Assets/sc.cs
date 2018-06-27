using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc : MonoBehaviour {
    public GameObject RELBOW;
    // Use this for initialization
    void Start () {
        RELBOW = GameObject.FindWithTag("Right Fore Arm");

        //Quaternion Right = Quaternion.identity;
        //Right.eulerAngles = new Vector3(0, 170f, 0);
        //RELBOW.transform.localRotation = Quaternion.Slerp(RELBOW.transform.localRotation, Right, 1f);
        StartCoroutine(move());
    }
    IEnumerator move()
    {
        Quaternion Right = Quaternion.identity;
        Right.eulerAngles = new Vector3(0, 150f, 0);
        RELBOW.transform.localRotation = Quaternion.Slerp(RELBOW.transform.localRotation, Right, Time.deltaTime * 0.5f);

        while (true)
        {
            RELBOW.transform.localRotation = Quaternion.Slerp(RELBOW.transform.localRotation, Right, Time.deltaTime * 0.5f);
            yield return new WaitForSeconds(0.01f);
            if (this.transform.localRotation.y >= 150)
            {
                break;
            }
        }
    }
    // Update is called once per frame
    void Update () {
        //Quaternion Right = Quaternion.identity;
        //Right.eulerAngles = new Vector3(0, 150f, 0);
        //RELBOW.transform.localRotation = Quaternion.Slerp(RELBOW.transform.localRotation, Right, Time.deltaTime * 0.5f);

        //StartCoroutine(move());
    }
}
