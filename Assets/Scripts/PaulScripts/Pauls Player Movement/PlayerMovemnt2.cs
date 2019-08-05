
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovemnt2 : MonoBehaviour //neue Interpretation des Player-Movemts, basierend auf Physi
{
    Vector2 Move;
    public float jumpForce = 20f;
    public float speed = 5.0f;
    Animator m_Animator;
    Rigidbody2D rb;
    public LayerMask groundLayer;
    public bool facingRight;
    bool isgrounded;
    int jmpsLeft;//doppelt Jump
    public bool isWalking;
    public bool vecwalk; 
    public Vector2 tempVect;

    bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 2.0f;


        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
    }

    void Flip()
    {
        //damit es mit projectilen functioniert
        transform.Rotate(0f, 180f, 0);
    }

    void Update()
    {
        //Eingabe von a oder d
        float h = Input.GetAxis("Horizontal");

        //dreht Spieler um
        if (h < 0 && !facingRight)
        {
            facingRight = true;
            Flip();
        }
        else if (h > 0 && facingRight)
        {
            Flip();
            facingRight = false;
        }


        //schaut ob sich der Charakter nach links oder rechts bewegt
        bool hasHorizontalInput = !Mathf.Approximately(h, 0f);
        isWalking = hasHorizontalInput;

        //setzt Animator Variable auf isWalking für Idle etc..
        m_Animator.SetBool("IsMoving", isWalking);


        if (Mathf.Abs(h) > 0)
            vecwalk = true;
        else
        {
            vecwalk = false;
        }

         tempVect = new Vector2(h, 0);
        //Bewegungsrichtung
        //tempVect = tempVect.normalized * speed;

        //bewegt den Charakter
        rb.AddForce(tempVect * Time.deltaTime * speed);



        //schaut ob Boden drunter ist
        if (Input.GetKeyDown("space") && jmpsLeft > 0)
        {
            rb.AddForce(new Vector2(0f, Input.GetAxisRaw("Jump") * jumpForce), ForceMode2D.Impulse);
            --jmpsLeft;
        }
    }



    //make sure u replace "floor" with your gameobject name.on which player is standing
    void OnCollisionEnter2D(Collision2D theCollision)
    {
        if (theCollision.gameObject.CompareTag("floor"))
        {
            isgrounded = true;
            jmpsLeft = 2;
            m_Animator.SetBool("IsJumping", isgrounded);
        }
    }

    //consider when character is jumping .. it will exit collision.
    void OnCollisionExit2D(Collision2D theCollision)
    {
        if (theCollision.gameObject.CompareTag("floor"))
        {
            isgrounded = false;
            //Jumpanimation
            m_Animator.SetBool("IsJumping", isgrounded);
        }
    }
}


