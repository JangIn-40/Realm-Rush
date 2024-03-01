using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 5;
    int currentHealthPoints = 0;

    void Start()
    {
        currentHealthPoints = maxHealth;
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
            Destroy(gameObject);
        }
    }
}
