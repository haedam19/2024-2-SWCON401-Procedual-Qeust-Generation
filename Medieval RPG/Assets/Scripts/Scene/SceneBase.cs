using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SceneBase : MonoBehaviour
{
    [Serializable]
    public struct MSG
    {
        public Character speaker;
        public string msg; 
    }

    [SerializeField] List<MSG> dialogText = new List<MSG>();

    // Start is called before the first frame update
    void Start()
    {
        List<Dictionary<string, object>> mike = CSVReader.Read("Dialog/dialog_mike.csv");

        MSG mg = new MSG();
        mg.speaker = GetComponent<Character>();
        mg.msg = "d";

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
