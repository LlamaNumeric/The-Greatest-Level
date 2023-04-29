using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rb;

    [SerializeField]
    private float speed = 8f;

    private float horz, vert;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        horz = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");

        //rotate camera
        float h = 10f * Input.GetAxis("Mouse X") * Time.deltaTime;
        transform.Rotate(0, h, 0);
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(horz, 0, vert);
        movement = transform.rotation * movement;

        rb.AddForce(movement.normalized * speed);

        anim.SetFloat("Horizontal", horz);
        anim.SetFloat("Vertical", vert);
    }
}
