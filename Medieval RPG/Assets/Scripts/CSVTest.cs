using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVTest : MonoBehaviour
{
    List<Dictionary<string, object>> text;
    // Start is called before the first frame update
    void Start()
    {
        text = CSVReader.Read("Dialog1");
        int length = text.Count;
        Debug.Log(length);
        for (int i = 0; i < length; i++)
        {
            print(text[i]["Message"].ToString());
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
