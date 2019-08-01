using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eccoEffect : MonoBehaviour
{
    public float TimeBtw;
    public float StartTimeBtw;
    public GameObject eco;
    public bool active;
    private void Start()
    {
        active = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (active == true)
        {
            if (TimeBtw <= 0)
            {
                GameObject instance = (GameObject)Instantiate(eco, transform.position, transform.rotation);
                TimeBtw = StartTimeBtw;
                Destroy(instance, 1.5f);
            }
            else
            {
                TimeBtw -= Time.deltaTime;
            }
        }
    }
}
