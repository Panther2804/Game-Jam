using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playpaul : MonoBehaviour
{
    public float ForceMultiplier;
    public float JumpMultiplier;
    public float InAirJumpMultiplier;
    public float setJumptime;
    public float Jumptime;
    public float InAirMultiplier;
    public bool Grounded = true;
    private Rigidbody2D rb;
    public Animator animator;
    public GameObject shot;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 force = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (Grounded)
            rb.AddForce(force * ForceMultiplier);
        else
            rb.AddForce(force * InAirMultiplier);

        animator.SetFloat("Speed", Mathf.Abs(force.x));

    }

    private void FixedUpdate()
    {

        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (Grounded)
                {
                    Jumptime = setJumptime;
                    rb.AddForce(new Vector3(0, JumpMultiplier, 0), ForceMode2D.Impulse);
                    Grounded = false;
                }
            }


            if (Input.GetKey(KeyCode.Space))
            {

                if (Jumptime > 1)
                {
                    Jumptime--;
                    rb.AddForce(new Vector3(0, (InAirJumpMultiplier * (Jumptime / setJumptime)), 0), ForceMode2D.Impulse);

                }
            }
        }


        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetBool("Shoot", true);
            //Instantiate(shot,transform.position);
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            animator.SetBool("Shoot", false);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Grounded = true;
    }
}
