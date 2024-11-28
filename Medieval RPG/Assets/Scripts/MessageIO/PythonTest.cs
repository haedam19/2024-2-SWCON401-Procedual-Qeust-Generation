using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PythonTest : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI pythonRcvdText = null;
    [SerializeField] TMP_InputField messageInputField = null;

    string tempStr = "Message";
    int numToSendToPython = 0;
    UdpSocket udpSocket;

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
        if (messageInputField.text != "")
        {
            udpSocket.SendData(messageInputField.text);
            messageInputField.text = null;
        }
        else
            udpSocket.SendData("NULL");
    }

    private void Start()
    {
        udpSocket = FindObjectOfType<UdpSocket>();
    }

    void Update()
    {
        pythonRcvdText.text = tempStr;
    }
}
