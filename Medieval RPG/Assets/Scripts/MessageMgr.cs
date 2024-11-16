using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageMgr : MonoBehaviour
{
    private static MessageMgr _instance;
    public static MessageMgr Instance
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

    private void Awake()
    {
        if(_instance == null)
            _instance = this;
        else
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
