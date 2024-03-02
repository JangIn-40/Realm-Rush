using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingCoin = 150;

    [SerializeField] int currentCoin;
    public int CurrentCoin{get {return currentCoin;}}

    void Awake()
    {
        currentCoin = startingCoin;
    }

    public void Deposit(int amount)
    {
        currentCoin += Mathf.Abs(amount);
    }

    public void WithDraw(int amount)
    {
        currentCoin -= Mathf.Abs(amount);

        if(currentCoin < 0)
        {
            //게임오버!
            ReloadScene();
        }
    }

    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
