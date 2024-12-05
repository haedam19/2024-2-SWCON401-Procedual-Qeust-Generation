using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageManager : MonoBehaviour
{
    private static MessageManager _instance;
    public static MessageManager Instance
    {
        get
        {
            if (null == _instance)
            {
                return null;
            }
            return _instance;
        }
    }

    public Character partner;
    public DialogUI _dialogUI;
    UdpSocket _udpSocket;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            _dialogUI.gameObject.SetActive(false);
        }
        else
            Destroy(gameObject);
    }

    /// <summary>
    /// 메시지로부터 대화 UI 텍스트 업데이트, 엔티티 상태 업데이트를 위한 정보를 추출합니다.
    /// </summary>
    /// <param name="msg"></param>
    public void ProcessRcvdData(string msg)
    {
        
    }

    /// <summary>
    /// 입력 메시지를 받아 파이썬에 보낼 데이터를 구성합니다.
    /// </summary>
    /// <param name="msg"></param>
    public void ProcessSendingData(string msg)
    {
        string data = string.Format("{{ \"name\":\"{0}\", \"gender\":\"{1}\", \"status\":\"{2}\", \"name\":\"{3}\" }}");
        _udpSocket.SendData(data);
    }

    public void StartDialog(Character partner, string initialSentence)
    {
        _dialogUI.gameObject.SetActive(true);
        _dialogUI.partnerNameField.text = partner.characterData.characterName;
        _dialogUI.rcvdText.text = initialSentence;
    }

    public void EndDialog()
    {

    }

    public string GetCharacterData(Character character)
    {
        // string data = string.Format("\"name\":\"{0}\", \"gender\":\"{1}\", \"status\":\"{2}\"")


        return "null";
    }
}
