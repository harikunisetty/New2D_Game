using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPostion : MonoBehaviour
{
    [Header("Fire")]
    [SerializeField] float speed = 20f;
    [SerializeField] Transform fireTrans;
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
            Fire();
    }
    void Fire()
    {
        Transform ammospawn = AmmoPath.SpawnAmmo(fireTrans.position, Quaternion.identity);
        ammospawn.GetComponent<Rigidbody2D>().AddForce(fireTrans.right* speed,ForceMode2D.Impulse);
    }
}
