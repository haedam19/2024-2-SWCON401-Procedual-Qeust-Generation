using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEntity
{
    public void ExportEntityData();

    public bool SetID(int id);

    public int GetID();
}
