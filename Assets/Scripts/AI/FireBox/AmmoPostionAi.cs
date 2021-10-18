using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPostionAi : MonoBehaviour
{
    [Header("Fire")]
    [SerializeField] Transform firePoint;
    [SerializeField] float timer = 10;
    [SerializeField] float startTimer;
    [SerializeField] GameObject Ammo;
    [SerializeField] float nextAttack;

    private void Start()
    {
        timer = startTimer;
    }
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = nextAttack;
            Instantiate(Ammo,firePoint.transform.position, transform.rotation);
        }

    }
}
