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

    public GameObject vid;

    private bool at_console = false;

    public bool vidOver = false;

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
        if (!vidOver)
        {
            StartCoroutine(Sec());
        }
        if (vidOver)
        {
            MyInput();
            Grounded = Physics.Raycast(transform.position, Vector3.down, PlayerHeight * 0.5f + 0.2f, WhatIsGround);
            if (at_console && Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(nextScene);
            }
        }
    }
    private void FixedUpdate()
    {
        if (vidOver)
        {
            MovePlayer();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "console")
        {
            obj.text = "press e to continu";
            at_console = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "console")
        {
            obj.text = "return to console";
            at_console = false;
        }
    }
    IEnumerator Sec()
    {
        yield return new WaitForSeconds(6.5f);
        vid.SetActive(false);
        vidOver = true;
    }
}
