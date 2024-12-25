using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

// 12.6 완성
public class Character : MonoBehaviour, IEntity
{
    [Serializable]
    public class CharacterData
    {
        // NPC 설정은 유니티 인스펙터에서 캐릭터 데이터를 통해 진행
        public int entityID;
        public const int type = (int)EntityManager.Type.Character;
        public string characterName;
        public int age;
        public int gender;
        public string[] status;
        public string[] personalities;
    }
    public CharacterData characterData;

    // personality와 status에 변화가 있을 경우 manipulation하기 쉬운 리스트를 통해 갱신
    // character data의 arrary representation은 json으로 추출하는 데에 사용
    public List<string> personalityInnerRep = new List<string>();
    public List<string> statusInnerRep = new List<string>();

    protected virtual void Start()
    {
        // 입력해둔 캐릭터 data를 innerRep 멤버변수에 동기화
        foreach(string v in characterData.personalities)
            personalityInnerRep.Add(v);
        foreach(string v in characterData.status)
            statusInnerRep.Add(v);
        
        EntityManager.Instance.RegisterEntity(this);
    }

    public void AddPersonality(string v)
    {
        personalityInnerRep.Add(v);
        characterData.personalities = personalityInnerRep.ToArray();
    }

    public void RemovePersonality(string v)
    {
        if(statusInnerRep.Remove(v))
            characterData.status = statusInnerRep.ToArray(); 
    }

    public void AddStatus(string v)
    {
        statusInnerRep.Add(v);
        characterData.status = statusInnerRep.ToArray();
    }

    public void RemoveStatus(string v)
    {
        if(statusInnerRep.Remove(v))
            characterData.status = statusInnerRep.ToArray(); 
    }

    [ContextMenu("Export Manually")]
    public void ExportEntityData()
    {
        string jsonData = JsonUtility.ToJson(characterData);
        string path = Path.Combine(Application.dataPath, "JSON Data", string.Format("Character_{0}.json", characterData.entityID));
        Debug.Log(path);
        File.WriteAllText(path, jsonData);
    }

    public bool SetID(int id)
    {
        // id 중복 방지를 위해 설정하려는 id를 사용 중인 entity가 있는지 확인
        if(EntityManager.Instance.GetEntity(id) == null)
        {
            characterData.entityID = id;
            return true;
        }
        else
            return false;
    }

    public int GetID()
    {
        return characterData.entityID;
    }
}
