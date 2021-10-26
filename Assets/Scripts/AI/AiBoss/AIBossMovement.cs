using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBossMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float xSpeed;
    [SerializeField] float Offset;
    [SerializeField] float distanceFormPlayer;
    [SerializeField] Transform Player;

    [Header("AiAttack")]

    public GameObject bullet;
    public GameObject bulletParent;
    [SerializeField] float ShootRange;
    [SerializeField] float startAttackTime;
    [SerializeField] float nextAtacckTime;
    [SerializeField] float restTime;


    [SerializeField] EnemyDamageHealth enemyHealth;
    [SerializeField] float Hitvalue = 5f;

    [SerializeField] GameObject pickEffect;
    Animator anim;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemyHealth = GetComponent<EnemyDamageHealth>();
        nextAtacckTime = startAttackTime;
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        distanceFormPlayer = Vector2.Distance(Player.position, transform.position);

        if (distanceFormPlayer <= ShootRange)
            {
                nextAtacckTime -= Time.deltaTime;
                if (nextAtacckTime <= 0)
                {
                    nextAtacckTime = restTime;
                    Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
                }
            }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, Offset);
        Gizmos.DrawWireSphere(transform.position, ShootRange);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {     
        if (other.gameObject.CompareTag("Bullet"))
        {
           /* Instantiate(pickEffect, transform.position, Quaternion.identity);*/
            enemyHealth.AiDamage(Hitvalue);
        }
    }
}
