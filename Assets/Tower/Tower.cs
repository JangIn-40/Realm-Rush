using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost = 75;

    public bool CreatTower(Tower tower, Vector3 position)
    {
        Bank bank = FindObjectOfType<Bank>();

        if(bank == null)
        {
            return false;
        }
        if(bank.CurrentCoin >= cost)
        {
            bank.WithDraw(cost);
            Instantiate(tower.gameObject, position, Quaternion.identity);
            return true;
        }
        return false;
    }
}
