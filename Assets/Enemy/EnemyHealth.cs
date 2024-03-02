using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 5;
    [SerializeField] int currentHealthPoints = 0;

    Enemy enemy;

    void OnEnable()
    {
        currentHealthPoints = maxHealth;
    }

    void Start()
    {
        enemy = GetComponent<Enemy>(); 
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        currentHealthPoints--;
        if (currentHealthPoints < 1)
        {
            enemy.RewardGold();
            gameObject.SetActive(false);
            
        }
    }
}
