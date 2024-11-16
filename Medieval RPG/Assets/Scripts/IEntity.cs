using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEntity
{
    public void SendEntityData();

    public bool SetID();

    public int GetID();
}
