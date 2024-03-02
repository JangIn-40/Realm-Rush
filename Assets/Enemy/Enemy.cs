using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int goldReward = 15;
    [SerializeField] int goldPenalty = 15;

    Bank bank;

    void Start()
    {
        bank = FindObjectOfType<Bank>();
    }

    public void RewardGold()
    {
        if(bank == null){ return; }
        bank.Deposit(goldReward);
    }

    public void PenaltyGold()
    {
        if(bank == null){ return; }
        bank.WithDraw(goldPenalty);
    }
}
