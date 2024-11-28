using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogUI : MonoBehaviour
{
    public TextMeshProUGUI partnerNameField = null;
    public TextMeshProUGUI rcvdText = null;
    public TMP_InputField messageInputField = null;

    public void UpdateRcvdText(string msg) { rcvdText.text = msg; }

    public void SendInputText()
    {
        string msg = messageInputField.text;

        if (msg != "")
        {
            MessageMgr.Instance.ProcessSendingData(msg);
            messageInputField.text = null;
        }
    }
}
