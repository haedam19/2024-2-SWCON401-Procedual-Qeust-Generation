using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Character : MonoBehaviour, IEntity
{
    [Serializable]
    public class CharacterData
    {
        public int entityID;
        public string characterName;
        public int age;
        public int gender;
        public string[] status;
        public string[] personalities;
    }
    public CharacterData characterData;

    public List<string> personalityInnerRep = new List<string>();
    public List<string> StatusInnerRep = new List<string>();

    public void AddPersonality(string v)
    {
        personalityInnerRep.Add(v);
        characterData.personalities = personalityInnerRep.ToArray();
    }

    public void RemovePersonality(string v)
    {
        if(StatusInnerRep.Remove(v))
            characterData.status = StatusInnerRep.ToArray(); 
    }

    public void AddStatus(string v)
    {
        StatusInnerRep.Add(v);
        characterData.status = StatusInnerRep.ToArray();
    }

    public void RemoveStatus(string v)
    {
        if(StatusInnerRep.Remove(v))
            characterData.status = StatusInnerRep.ToArray(); 
    }

    public void ExportEntityData()
    {
        string jsonData = JsonUtility.ToJson(characterData);
        string path = Path.Combine(Application.dataPath, string.Format("/Character_{0}.json", characterData.entityID));
    }

    public bool SetID(int id)
    {
        return true;
    }

    public int GetID()
    {
        return characterData.entityID;
    }
}
