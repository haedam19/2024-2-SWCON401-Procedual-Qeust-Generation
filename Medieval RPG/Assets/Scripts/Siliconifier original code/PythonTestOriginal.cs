﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PythonTestOriginal : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI pythonRcvdText = null;
    [SerializeField] TextMeshProUGUI sendToPythonText = null;

    string tempStr = "Sent from Python xxxx";
    int numToSendToPython = 0;
    UdpSocketOriginal udpSocket;

    public void QuitApp()
    {
        print("Quitting");
        Application.Quit();
    }

    public void UpdatePythonRcvdText(string str)
    {
        tempStr = str;
    }

    public void SendToPython()
    {
        udpSocket.SendData("Sent From Unity: " + numToSendToPython.ToString());
        numToSendToPython++;
        sendToPythonText.text = "Send Number: " + numToSendToPython.ToString();
    }

    private void Start()
    {
        udpSocket = FindObjectOfType<UdpSocketOriginal>();
        sendToPythonText.text = "Send Number: " + numToSendToPython.ToString();
    }

    void Update()
    {
        pythonRcvdText.text = tempStr;
    }
}
