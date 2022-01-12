using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGame : MonoBehaviour
{
     Rigidbody2D rb;
     Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator> ();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpact(); //прыжок по команде
        }
        if (Input.GetAxis("Horizontal") == 0)
        {
            anim.SetInteger("darling", 1);
        }
        else
        {
            Flip();
            anim.SetInteger("darling", 2);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetInteger("darling", 3);
        }

        CheckingGround();
    }

    void OnTriggerEnter2d(Collider shit)
    {
        if (shit.gameObject.tag == "Finish")
        {
            Application.LoadLevel("Scene2");
        }
    }
    void Flip()
    {
        if (Input.GetAxis("Horizontal") < 0)
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        if (Input.GetAxis("Horizontal") > 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * 12f, rb.velocity.y);

    }


    void jumpact()
    {
        CheckingGround();
        if (onGround) {
            rb.AddForce(transform.up * 20f, ForceMode2D.Impulse); //сам прыжок
        }
    

    }

    public bool onGround;
    public Transform GroundCheck;
    public float checkRadius = 2.0f;
    public LayerMask Ground;
    void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position,checkRadius,Ground);
    }

}
