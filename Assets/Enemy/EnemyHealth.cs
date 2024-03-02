using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 5;
    [SerializeField] int currentHealthPoints = 0;

    void OnEnable()
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
            gameObject.SetActive(false);
        }
    }
}
