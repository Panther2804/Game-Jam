using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashSkill : MonoBehaviour
{
    private Rigidbody2D rb;
    
    private float dashTime;
    public float startDashTime;
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (dashTime <= 0)
            {






                if (GetComponent<PlayerMovement>().facingRight == true)
                {
                    rb.AddForce(new Vector2(-20000f, 0f));
                }
                else if (GetComponent<PlayerMovement>().facingRight == false)
                {
                    rb.AddForce(new Vector2(20000f, 0f));
                }
                dashTime = startDashTime;
            }
           
        }
        dashTime -= Time.deltaTime;
    }
}
