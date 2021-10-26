using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManagaer : MonoBehaviour
{
    [Header("PlayerHealth")]

    [SerializeField] float AIHealth;
    private float maximumAiHealth = 100f;
    void Start()
    {
        AIHealth = maximumAiHealth;
    }
    public void PlayerDamage(float hitvalue)
    {
        if (AIHealth > 0f)
        {
            AIHealth -= hitvalue;
            UiManager.Instance.PlayerHealthUI(AIHealth);

            if (AIHealth <= 0f)
                PlayerDead();
        }
        else
        {
            PlayerDead();
        }
    }

    public void PlayerDead()
    {
        Destroy(gameObject);
    }
}
