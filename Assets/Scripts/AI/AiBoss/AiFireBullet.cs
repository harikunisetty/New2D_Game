using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiFireBullet : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float lifeTime = 2f;
    public float speed;
    [SerializeField] Rigidbody2D rb2d;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Start()
    {

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
