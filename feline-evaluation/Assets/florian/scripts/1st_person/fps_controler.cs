using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class fps_controler : MonoBehaviour
{
    public float speed;

    public TMPro.TextMeshProUGUI obj;

    public int nextScene;

    public float PlayerHeight;
    public LayerMask WhatIsGround;
    bool Grounded;
    public float GroundDrag;

    float hotizontalInput;
    float verticalInput;

    Vector3 moveDir;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody> ();
        rb.freezeRotation = true;
    }

    private void MyInput()
    {
        hotizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        moveDir = transform.forward * verticalInput + transform.right * hotizontalInput;

        rb.AddForce(moveDir.normalized * speed * 10f, ForceMode.Force);

        if (Grounded)
            rb.drag = GroundDrag;
        else
            rb.drag = 0;
    }

    // Update is called once per frame
    void Update()
    {
        MyInput();
        Grounded = Physics.Raycast(transform.position, Vector3.down, PlayerHeight * 0.5f + 0.2f, WhatIsGround);
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "console")
        {
            obj.text = "press e to continu";
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(nextScene);
            }
        }
    }
}
