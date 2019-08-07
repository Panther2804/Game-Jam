using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eggerBehavior : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform target;
    private float timeBtwJumps;
    public float StartTimeBtwJumps;
    private GameObject stickObject;
    private bool sticked = false;
    //rotation
    private Vector3 relativePosition;
    private bool lookingLeft;
    public float sightRange;
        
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwJumps = StartTimeBtwJumps;
        
    }

    // Update is called once per frame
    void Update()
    {
        #region rotation
        relativePosition = transform.position - target.position;
        if (transform.rotation.y == 0) { lookingLeft = true; }
        else if (transform.rotation.y == 180) { lookingLeft = false; }

        if (relativePosition.x > 0 && lookingLeft == false)
        {
            Flip();
            lookingLeft = true;
        }
        else if (relativePosition.x < 0 && lookingLeft == true)
        {
            Flip();
            lookingLeft = false;
        }
        #endregion

        #region jump
        if (timeBtwJumps <= 0 && sticked == false && Vector2.Distance(transform.position,target.position)<sightRange)
        {
            if (lookingLeft == true)
            {
                rb.AddForce(new Vector2(Vector2.Distance(target.position, transform.position) * -100,
                    (Vector2.Distance(target.position, transform.position) + 10) * 100));
                timeBtwJumps = StartTimeBtwJumps;
                Debug.Log("ForceApplied");
            }
            else
                if (lookingLeft == false)
            {
                rb.AddForce(new Vector2(Vector2.Distance(target.position, transform.position) * 100,
                    (Vector2.Distance(target.position, transform.position) + 10) * 100));
                timeBtwJumps = StartTimeBtwJumps;
                Debug.Log("ForceApplied");
            }
        }
        else
        {
            timeBtwJumps -= Time.deltaTime;
        }
        #endregion
    }
    private void OnCollisionEnter2D( Collision2D collision)
    {if (collision.gameObject.CompareTag("Player")){
            gameObject.transform.parent = collision.gameObject.transform;
            Destroy(rb);
            GetComponentInParent<PlayerMovement>().enabled = false;
            GetComponent<eggerSuicide>().enabled = true;
            this.enabled = false;
        }
    }
    public void Flip()
    {
        transform.Rotate(0f, 180f, 0);
    }
}

