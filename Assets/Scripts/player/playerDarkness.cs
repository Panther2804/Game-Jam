using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDarkness : MonoBehaviour
{
    public float darkness;
    // Start is called before the first frame update
    void Start()
    {
        darkness = 1f;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        darkness += 0.001f;
    }
    public void darknessUsed(float ammount)
    {
        darkness -= ammount;
    }
}
