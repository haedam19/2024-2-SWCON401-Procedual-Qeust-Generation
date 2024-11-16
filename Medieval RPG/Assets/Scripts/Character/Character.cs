using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour, IEntity
{
    public enum Gender { Male, Female }

    public int entityID;
    public string characterName;
    public int age;
    public Gender gender;
    public List<string> personalities = new List<string>();
    public List<string> status = new List<string>();

    public void AddStatus(string v) { status.Add(v); }
    public void RemoveStatus(string v) {status.Remove(v); }

    public void SendEntityData()
    {

    }

    public bool SetID()
    {
        return true;
    }

    public int GetID()
    {
        return entityID;
    }
}
