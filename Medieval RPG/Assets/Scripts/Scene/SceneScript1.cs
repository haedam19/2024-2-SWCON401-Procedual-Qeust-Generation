using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UIElements;

public class SceneScript1 : MonoBehaviour
{
    enum CharName { Aladdin, Dalia, Mike }

    public string[] names = new string[2];
    int messageCnt = 0;
    public List<Dictionary<string, object>> dialogData;

    // Start is called before the first frame update
    void Start()
    {
        // Header: Character, Message, InputFlag
        dialogData = CSVReader.Read("dialog");
        //BindParameter();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BindParameter()
    {
        print(dialogData[0]["Character"].ToString());
        //¿Ï
        for (int i = 0; i < dialogData.Count; i++)
        {
            int characterCode = int.Parse(dialogData[i]["Character"].ToString());
            dialogData[i]["Character"] = names[characterCode];

            if (dialogData[i]["Message"].ToString().Contains("{0}"))
                dialogData[i]["Message"] = dialogData[i]["Message"].ToString().Replace("{0}", names[0]);
            if (dialogData[i]["Message"].ToString().Contains("{1}"))
                dialogData[i]["Message"] = dialogData[i]["Message"].ToString().Replace("{1}", names[1]);
        }
    }
}
