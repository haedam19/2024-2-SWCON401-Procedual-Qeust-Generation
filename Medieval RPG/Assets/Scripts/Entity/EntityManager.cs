using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    private static EntityManager _instance;
    public static EntityManager Instance
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

    public enum Type { Character, Item, Location }
    public enum Gender { Male, Female }

    public List<IEntity> entities;
    public int numOfEntities;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            entities = new List<IEntity>();
        }
        else
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        numOfEntities = entities.Count;
    }

    public IEntity GetEntity(int id)
    {
        IEntity entity = null;
        foreach(IEntity elem in entities)
        {
            if (elem.GetID() == id)
            {
                entity = elem;
                break;
            }
        }
        return entity;
    }

    public void RegisterEntity(IEntity entity)
    {
        if (GetEntity(entity.GetID()) == null)
            entities.Add(entity);
        else
            Debug.LogError("추가하려는 엔티티와 동일한 ID를 지닌 엔티티가 존재합니다.");
    }
}
