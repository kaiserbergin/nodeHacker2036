using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPool {
    public int poolIndex;
    public List<GameObject> pooledObjects;

    public ObjectPool(int poolIndex, List<GameObject> pooledObjects) {
        this.poolIndex = poolIndex;
        this.pooledObjects = pooledObjects;
    }
}
