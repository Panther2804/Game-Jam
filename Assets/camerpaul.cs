using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerpaul : MonoBehaviour
{

    public  GameObject player;
    Rigidbody2D rb;
    public float smoothTime = .5f;
    private float offset;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        offset = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pvel = (Vector3) player.GetComponent<Rigidbody2D>().velocity;
        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position, ref pvel, smoothTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, offset);
    }
}
