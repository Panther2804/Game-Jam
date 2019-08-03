using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinnerRotation : MonoBehaviour
{
    private Transform playerLocation;
    // Start is called before the first frame update
    void Start()
    {
        playerLocation = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        facePlayer();
    }
    void facePlayer()
    {
        Vector2 direction = new Vector2(playerLocation.position.x - transform.position.x,
            playerLocation.position.y - transform.position.y
            );
        transform.up = direction;
    }
}
