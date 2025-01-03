using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Item : MonoBehaviour, IEntity
{
    [Serializable]
    public class ItemData
    {
        public int entityID;
        public const int type = (int)EntityManager.Type.Item;
        public string itemName;
    }

    public ItemData itemData;
    public bool isObtained;
    SpriteRenderer spRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("Export Manually")]
    public void ExportEntityData()
    {
        string jsonData = JsonUtility.ToJson(itemData);
        string path = Path.Combine(Application.dataPath, "JSON Data", string.Format("Item_{0}.json", itemData.entityID));
        Debug.Log(path);
        File.WriteAllText(path, jsonData);
    }

    public bool SetID(int id)
    {
        // id 중복 방지를 위해 설정하려는 id를 사용 중인 entity가 있는지 확인
        if (EntityManager.Instance.GetEntity(id) == null)
        {
            itemData.entityID = id;
            return true;
        }
        else
            return false;
    }

    public int GetID()
    {
        return itemData.entityID;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Player player;
        if (col.TryGetComponent<Player>(out player))
        {
            isObtained = true;
            spRenderer.enabled = false;
            // 지식 그래프에 획득 여부 체크
        }
    }

}
