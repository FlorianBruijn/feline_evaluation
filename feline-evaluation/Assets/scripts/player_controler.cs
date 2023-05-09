using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controler : MonoBehaviour
{
    public Rigidbody rb;
    public Transform planet;
    public float acceleration = 9.807f;
    public float jump = -10000f;
    public bool onFloor;

    private Quaternion _lookRotation;
    private Vector3 _direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _direction = (planet.position - transform.position).normalized;
        _lookRotation = Quaternion.LookRotation(_direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, 1);


        if (!onFloor)
        {
            rb.AddForce((planet.position - transform.position).normalized * acceleration);
        }
        if (Input.GetKeyDown(KeyCode.Space) && onFloor)
        {
            rb.AddForce((planet.position - transform.position).normalized * jump);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "planet")
        {
            onFloor = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "planet")
        {
            onFloor = false;
        }
    }
}
