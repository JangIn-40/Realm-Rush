using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 5;
    
    [Tooltip("Add amount maxHealth when enemy dies")]
    [SerializeField] int difficultyRamp = 1;

    int currentHealthPoints = 0;

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
            maxHealth += difficultyRamp;
            gameObject.SetActive(false);
            
        }
    }
}
