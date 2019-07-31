using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector2 Move;
    public float jumpForce = 20f;
    public float speed = 5.0f;
    Animator m_Animator;
    Rigidbody2D rb;
    public LayerMask groundLayer;
    bool facingRight;
    bool isgrounded;

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
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void FixedUpdate()
    {
        //Eingabe von a oder d
        float h = Input.GetAxis("Horizontal");
        //dreht Spieler um
        if (h > 0&&!facingRight)
        {
            Flip();
        }
        else if (h < 0 && facingRight)
        {
            Flip();
        }
        //schaut ob sich der Charakter bewegt
        bool hasHorizontalInput = !Mathf.Approximately(h, 0f);
        bool isWalking = hasHorizontalInput;
        //setzt Animator Variable auf isWalking für Idle etc..
        m_Animator.SetBool("IsMoving", isWalking);

        Vector3 tempVect = new Vector3(h, 0, 0);
        //Bewegungsrichtung
        tempVect = tempVect.normalized * speed;
        //bewegt den Charakter
        rb.MovePosition(rb.transform.position + tempVect);
        //schaut ob Boden drunter ist
        if (isgrounded == true)
        {
            rb.AddForce(new Vector2(0f, Input.GetAxisRaw("Vertical")), ForceMode2D.Impulse);
        }
    }



    //make sure u replace "floor" with your gameobject name.on which player is standing
    void OnCollisionEnter2D(Collision2D theCollision)
    {
        if (theCollision.gameObject.CompareTag("floor"))
        {
            isgrounded = true;
        }
    }

    //consider when character is jumping .. it will exit collision.
    void OnCollisionExit2D(Collision2D theCollision)
    {
        if (theCollision.gameObject.CompareTag("floor"))
        {
            isgrounded = false;
        }
    }
}


