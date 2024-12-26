using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SceneScript1 : MonoBehaviour
{
    enum CharName { Aladdin, Dalia, Mike }

    public string[] names = new string[2];
    int messageCnt = 0;
    public List<Dictionary<string, object>> dialogData;

    // Start is called before the first frame update
    void Start()
    {
        dialogData = CSVReader.Read("dialog");


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BindParameter()
    {
        for (int i = 0; i < dialogData.Count; i++)
        {
            int j = int.Parse(dialogData[i]["Character"].ToString());
        }
    }
}
