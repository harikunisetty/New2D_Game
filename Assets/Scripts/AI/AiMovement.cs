using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMovement : MonoBehaviour
{
    public float speed;
    public float distance;
    public bool moveRight;
    public Transform groundDetection;

    void Start()
    {
        
    }
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D ground = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (ground.collider == false)
        {
            if (moveRight == false)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                moveRight = false;
            }

            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moveRight = true;
            }
        }
        if (ground.collider == false)
        {
            if (moveRight ==true)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moveRight = false;
            }

            else
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                moveRight = true;
            }
        }
            

    }
   
}
