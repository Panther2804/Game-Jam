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

        if (timeBtwJumps <= 0 && sticked == false)
        {
            rb.AddForce(new Vector2( Vector2.Distance(target.position,transform.position )* -100,
                (Vector2.Distance(target.position, transform.position) +10) * 100)) ;
            timeBtwJumps = StartTimeBtwJumps;
            Debug.Log("ForceApplied");
        }
        else
        {
            timeBtwJumps -= Time.deltaTime;
        }
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
}
