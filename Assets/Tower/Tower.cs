using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost = 75;
    [SerializeField] float buildDelay = 0.5f;

    void Start()
    {
        StartCoroutine(Build());
    }

    IEnumerator Build()
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(false);
            foreach(Transform granchild in child)
            {
                granchild.gameObject.SetActive(false);
            }
        }

        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(true);
            yield return new WaitForSeconds(buildDelay);
            
            foreach(Transform granchild in child)
            {
                granchild.gameObject.SetActive(true);
            }

        }

        
    }

    public bool CreatTower(Tower tower, Vector3 position)
    {
        Bank bank = FindObjectOfType<Bank>();

        if(bank == null)
        {
            return false;
        }
        
        if(bank.CurrentCoin >= cost)
        {
            Instantiate(tower, position, Quaternion.identity);
            bank.WithDraw(cost);
            return true;
        }

        return false;
    }
}
