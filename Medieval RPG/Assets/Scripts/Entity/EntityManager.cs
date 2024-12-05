using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    public enum Type { Character, Item, Location }

    List<IEntity> entities;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
