using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class egg : MonoBehaviour
{
    private Rigidbody2D rb;
    public float TriggerDistanceToPlayer;
    private Transform Target;
    //Shell and enemy
    public GameObject egger;
    public GameObject shellLeft;
    public GameObject shellRight;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, Target.position) < TriggerDistanceToPlayer)
        {
            Debug.Log("Gravity changed");
            rb.gravityScale = 1f;

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(shellLeft, transform.position, transform.rotation);
            Instantiate(shellRight, transform.position, transform.rotation);
        Instantiate(egger, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }
}
