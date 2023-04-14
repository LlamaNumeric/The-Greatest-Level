using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rb;

    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float jumpHeight = 5f;

    private float horz, vert, up;
    private bool hasJumped = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horz = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");
        hasJumped = Input.GetButtonDown("Jump");
        up = hasJumped ? jumpHeight : 0;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(horz, 0, vert);

        rb.AddForce(movement * speed);
        rb.AddForce(Vector3.up * jumpHeight);

        anim.SetFloat("Horizontal", horz);
        anim.SetFloat("Vertical", vert);
    }
}
