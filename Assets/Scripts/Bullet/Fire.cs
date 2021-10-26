using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] float lifetime = 3f;
    [SerializeField] GameObject Effect;
  

    private void OnEnable()
    {
        Invoke("Die", lifetime);
    }

    void Die()
    {
        CancelInvoke();
        gameObject.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            gameObject.SetActive(false);
            GameManager.Instance.UpdateKills();
          

            Debug.Log("Touch Enemy");
        }

        if (other.CompareTag("AIBossEnemy"))
        {
            gameObject.SetActive(false);
            Instantiate(Effect, transform.position, Quaternion.identity);
        }
    }
}
