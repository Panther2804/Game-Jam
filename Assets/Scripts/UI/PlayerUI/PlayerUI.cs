using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public GameObject PLayer;
    // Start is called before the first frame update
    void Start()
    {
        PLayer=GameObject.FindGameObjectWithTag("Player")
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
