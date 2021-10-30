using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level : MonoBehaviour
{
    public GameObject nameLevel;
    public float lifetime = 3f;
    private void OnEnable()
    {
        Invoke("Die", lifetime);
    }

    void Die()
    {
        CancelInvoke();
        gameObject.SetActive(false);
    }
}
