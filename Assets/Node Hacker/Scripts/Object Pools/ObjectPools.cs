using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPools : MonoBehaviour {
    public static ObjectPools instance = null;

    public List<PoolSettings> poolSettings;
    private Dictionary<GameObject, ObjectPool> pools;

    private void Awake() {
        if(instance == null) {
            instance = this;
        } else if(instance != this) {
            Destroy(gameObject);
        }
        pools = new Dictionary<GameObject, ObjectPool>();
    }
    // Use this for initialization
    void Start () {
		foreach(PoolSettings poolSetting in poolSettings) {
            List<GameObject> gameObjList = new List<GameObject>();
            for(int i = 0; i < poolSetting.amount; i++) {
                GameObject newObj = Instantiate(poolSetting.pooledObject);
                newObj.SetActive(false);
                gameObjList.Add(newObj);
            }
            pools.Add(
                poolSetting.pooledObject,
                new ObjectPool(0, gameObjList)
            );
            Debug.Log($"game object list of: {pools[poolSetting.pooledObject].pooledObjects.Count}");
        } 
	}
	
	public GameObject SpawnObject(GameObject requestedPrefab) {
        if(pools.ContainsKey(requestedPrefab)) {
            ObjectPool prefabPool = pools[requestedPrefab];
            int initialPoolIndex = prefabPool.poolIndex;

            for (int i = prefabPool.poolIndex; i < prefabPool.pooledObjects.Count; i++) {
                if(!prefabPool.pooledObjects[i].activeInHierarchy) {
                    return ReturnActivatedPrefab(prefabPool.pooledObjects[i]);
                }
            }
            for (int i = 0; i < initialPoolIndex; i++) {
                if (!prefabPool.pooledObjects[i].activeInHierarchy) {
                    return ReturnActivatedPrefab(prefabPool.pooledObjects[i]);
                }
            }
        }
        return null;
    }

    private GameObject ReturnActivatedPrefab(GameObject prefab) {
        prefab.SetActive(true);
        return prefab;
    }
}
