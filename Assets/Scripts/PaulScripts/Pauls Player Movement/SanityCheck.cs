using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanityCheck : MonoBehaviour
{

    public bool testupdate;
    public bool testfixedupdate;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0)
            testupdate = true;
        else
            testupdate = false;


    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0)
            testfixedupdate = true;
        else
            testfixedupdate = false;

    }
}
