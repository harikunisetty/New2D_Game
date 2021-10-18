using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] GameObject player;
    [SerializeField] float lifeTime = 2f;
    public float speed=5f;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDirection = (player.transform.position - transform.position).normalized * speed;
        rb2d.velocity = new Vector2(moveDirection.x, moveDirection.y);
        /*gameObject.SetActive(false);*/
    }
    private void OnEnable()
    {
        Invoke("Die", lifeTime);
    }

    void Die()
    {
        CancelInvoke();
        gameObject.SetActive(false);
    }
}
