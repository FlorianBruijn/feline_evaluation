using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;
    public Transform planet;
    public float gravity = 9.98f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //zwaartekracht naar planeeten
        rb.AddForce((planet.position - transform.position).normalized * gravity * Time.deltaTime);
    }
}
