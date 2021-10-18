using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageHealth : MonoBehaviour
{
    [Header("AIHealth")]

    [SerializeField] float AIHealth;
    private float maximumAiHealth = 100f;
    [SerializeField] GameObject pickEffect;
    void Start()
    {
        AIHealth = maximumAiHealth;
    }
    public void AiDamage(float hitvalue)
    {
        if (AIHealth > 0f)
        {
            AIHealth -= hitvalue;
            /*UIManager.Instance.AiHealthUI(AIHealth);*/

            if (AIHealth <= 0f)
                EnemyDead();
        }
        else
        {
            EnemyDead();
            Instantiate(pickEffect, transform.position, Quaternion.identity);
        }
    }

    public void EnemyDead()
    {

        Destroy(gameObject);
    }
}
