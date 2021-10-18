using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float RestartTimer;

    public void MoveUp()
    {
        rb.velocity = transform.up * speed;
    }
    public void MoveDown()
    {
        rb.velocity = -transform.up * speed;
    }
    // Update is called once per frame
    void Start()
    {
        InvokeRepeating("MoveUp", 0, RestartTimer);
        InvokeRepeating("MoveDown", RestartTimer/2,RestartTimer);
    }
}
