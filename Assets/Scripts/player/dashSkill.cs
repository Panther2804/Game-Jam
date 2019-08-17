using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashSkill : MonoBehaviour
{
    private Rigidbody2D rb;
    
    private float dashTime;
    public float startDashTime;
    private Animator anim;
    public GameObject eco;
    public Transform dashDust;
    public ParticleSystem dashPart;
   
    
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            
            if (dashTime <= 0)
            {
                if (GetComponent<playerDarkness>().darkness >= 0)
                {

                    anim.SetTrigger("dash");


                    StartCoroutine(wait());


                }
            }
           
        }
        dashTime -= Time.deltaTime;
    }
    public IEnumerator wait()
    {
        yield return new WaitForSeconds(0.05f);
        if (GetComponent<PlayerMovement>().facingRight == true)
        {
            Instantiate(dashPart, dashDust.position, dashDust.rotation);
            dashPart.Play();
                GameObject instance = (GameObject)Instantiate(eco, transform.position, transform.rotation);

                rb.AddForce(new Vector2(-10000f, 0f));
            Debug.Log("forceApplied");
                Destroy(instance, 1.5f);
            GetComponent<playerDarkness>().darknessUsed(0.5f);
            Debug.Log("DarknessSubtrakted");
            rb.velocity = Vector2.zero;

            
           
        }
        else if (GetComponent<PlayerMovement>().facingRight == false)
        {
            Instantiate(dashPart, dashDust.position, dashDust.rotation);
            dashPart.Play();
            GameObject instance = (GameObject)Instantiate(eco, transform.position, transform.rotation);
                rb.AddForce(new Vector2(10000f, 0f));
            Debug.Log("forceApplied");
            Destroy(instance, 1.5f);
            GetComponent<playerDarkness>().darknessUsed(0.2f);
            Debug.Log("DarknessSubtrakted");
                rb.velocity = Vector2.zero;
           

        }
        dashTime = startDashTime;
        
        
    }
}
