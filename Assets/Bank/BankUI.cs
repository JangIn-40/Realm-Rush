using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BankUI : MonoBehaviour
{
    Bank bank;
    TextMeshProUGUI displayCoin;

    void Start()
    {
        bank = FindObjectOfType<Bank>();
        displayCoin = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        UpdateBankCoin();
    }

    void UpdateBankCoin()
    {
        displayCoin.text = "Coin : " + bank.CurrentCoin.ToString();
    }
}
