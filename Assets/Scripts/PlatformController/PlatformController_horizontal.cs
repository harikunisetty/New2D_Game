using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController_horizontal : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float RestartTimer;

    public void MoveRight()
    {
        rb.velocity = transform.right * speed;
    }
    public void MoveLeft()
    {
        rb.velocity = -transform.right * speed;
    }
    // Update is called once per frame
    void Start()
    {
        InvokeRepeating("MoveRight", 0, RestartTimer);
        InvokeRepeating("MoveLeft", RestartTimer / 2, RestartTimer);
    }
}
