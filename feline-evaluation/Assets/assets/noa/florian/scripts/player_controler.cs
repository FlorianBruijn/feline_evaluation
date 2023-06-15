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

    public float horInput;
    public float verInput;

    public float speed = 10f;

    public Vector3 moveDir;
    public Transform orientation;

    private Quaternion _lookRotation;
    private Vector3 _direction;
    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        //rotation to planet
        _direction = (planet.position - transform.position).normalized;
        _lookRotation = Quaternion.LookRotation(_direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, 1);
        //gravity
        rb.AddForce((planet.position - transform.position).normalized * acceleration);

        setInput();
        move();


        if (Input.GetKeyDown(KeyCode.Space) && onFloor)
        {
            rb.AddForce((planet.position - transform.position).normalized * jump);
        }
    }

    private void setInput()
    {
        horInput = Input.GetAxisRaw("Horizontal");
        verInput = Input.GetAxisRaw("Vertical");
    }

    private void move()
    {
        moveDir = orientation.up * verInput + orientation.right * horInput;

        rb.AddForce(moveDir.normalized * speed, ForceMode.Force);
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
