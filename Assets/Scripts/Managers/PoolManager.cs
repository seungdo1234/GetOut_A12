using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag; // key 값
        public GameObject prefab; // 실제 생성될 오브젝트
        public int size; // 한번에 몇개를 생성할 것인지
        public Transform parentTransform; // 부모 오브젝트
    }

    [Header("# Pool Info")]
    [SerializeField] private List<Pool> pools = new List<Pool>();
    private Dictionary<string, List<PoolObject>> poolDictionary;
    
    
    private void Awake()
    {
        // 딕셔너리 초기화
        poolDictionary = new Dictionary<string, List<PoolObject>>();
        
        // pools에 있는 모든 오브젝트를 탐색하고 정해놓은 size만큼 프리팹을 미리 만들어 놓음
        foreach (Pool pool in pools)
        {
            List<PoolObject> list = new List<PoolObject>();
            poolDictionary.Add(pool.tag,list);
            AddPoolObject(pool.tag);
        }
    }

 
    private void AddPoolObject(string tag) // 프리팹 생성
    {
        Pool pool = pools.Find(obj => tag == obj.tag);
        
        // pool.size만큼 프리팹을 생성 -> 비활성화 -> 리스트에 넣어줌
        for (int i = 0; i < pool.size; i++)
        {
            PoolObject poolObj = Instantiate(pool.prefab, pool.parentTransform).GetComponent<PoolObject>();
            poolObj.gameObject.SetActive(false);
            poolDictionary[tag].Add(poolObj);
        }
    }

    // 이미 생성된 오브젝트 풀에서 프리팹을 가져옴
    public PoolObject SpawnFromPool(string tag)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            return null;
        }

        PoolObject poolObject = null;
        
        for (int i = 0; i < poolDictionary[tag].Count; i++)
        {
            if (!poolDictionary[tag][i].gameObject.activeSelf)
            {
                poolObject = poolDictionary[tag][i];
                break;
            }

            if (i == poolDictionary[tag].Count - 1) // 모든 오브젝트가 활성화 됐을 때 
            {
                AddPoolObject(tag);
                poolObject = poolDictionary[tag][i + 1];
            }
        }
        
        poolObject.gameObject.SetActive(true);
        
        return poolObject;
    }
    
}