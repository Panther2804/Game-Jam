using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    private GameObject PLayer;
    public Slider PlayerHPBAr;
    private int playerHealth;
    public Image playerDarknessMeter;
    // Start is called before the first frame update
    void Start()
    {
        PLayer = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        playerHealth = PLayer.GetComponent<status>().health;
        PlayerHPBAr.value = playerHealth;
        playerDarknessMeter.fillAmount = PLayer.GetComponent<playerDarkness>().darkness;
        
    }
}
