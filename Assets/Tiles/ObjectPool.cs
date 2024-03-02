using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] int poolSize = 5;
    [SerializeField] float instanceDelay = 1f;

    GameObject[] pool;

    void Awake()
    {
        populatePool();
    }

    void Start()
    {
        StartCoroutine(InstanceEnemy());
    }

    void populatePool()
    {
        pool = new GameObject[poolSize];

        for(int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemyPrefab, transform /*transform.position, Quaternion.identity*/);
            // gameObject.SetActive(false); 잘못생각함 오브젝트풀링안의 겜오브젝트를 비활성화해야하는데 오브젝트풀링을 비활성화하는 코드임
            pool[i].SetActive(false);
        }
    }

    IEnumerator InstanceEnemy()
    {
        while(Application.isPlaying)
        {
            EnableObjectPool();
            yield return new WaitForSeconds(instanceDelay);
        }
    }

    void EnableObjectPool()
    {
        for(int i = 0; i < pool.Length; i++)
        {
            if(pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }
}
