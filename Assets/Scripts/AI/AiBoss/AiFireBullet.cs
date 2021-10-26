using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiFireBullet : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float lifeTime = 2f;
    [SerializeField] GameObject effect;
    public float speed;
    [SerializeField] Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        Invoke("Die", lifeTime);
    }
    void Update()
    {
        Vector2 moveDirection = (player.transform.position - transform.position).normalized * speed;
        rb2d.velocity = new Vector2(moveDirection.x, moveDirection.y);
        /*gameObject.SetActive(false);*/
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 7)
        {
            gameObject.SetActive(false);
            Instantiate(effect, transform.position, Quaternion.identity);
        }
    }
    public void Die()
    {
        CancelInvoke();
        Destroy(this.gameObject);
    }
    
}
