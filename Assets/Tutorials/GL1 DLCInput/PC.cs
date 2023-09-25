using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC : MonoBehaviour
{
    public float speed;

    private Vector3 moveDirection;


    public float jumpHeight;
    private Vector3 jump;
    private Rigidbody rb;
    private bool grounded = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        jump = new Vector3(0,jumpHeight,0);
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal") * speed, 0, Input.GetAxis("Vertical")* speed);
        transform.Translate(moveDirection*Time.deltaTime);

        if(Input.GetKeyDown("space") && grounded)
        {
            rb.AddForce(jump,ForceMode.Impulse);
            grounded = false;
        }
    }

    void OnCollisionEnter() 
    {
        grounded = true;
    }
}
