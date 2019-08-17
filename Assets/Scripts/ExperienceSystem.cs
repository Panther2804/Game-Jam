using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceSystem : MonoBehaviour
{
    public int XP;
    public int currentLevel;
    public int xpNextLevel;
    public int differenceXp;
    public int totaldifference;
    public Text lvlText;

    // Start is called before the first frame update
    void Start()
    {
        currentLevel = 0;
        SetLvlText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateEx(int xp)
    {
        XP += xp;

        int crrntLvl = (int)(0.1f * Mathf.Sqrt(XP));

        if (currentLevel != crrntLvl)
        {
            currentLevel = crrntLvl;
            SetLvlText();
        }
            

        //Methode aufrufen UI neue Skills freischalten

        int xpNextLevel = 100 * (currentLevel + 1) * (currentLevel + 1);
        int differenceXp = xpNextLevel - XP;
        int totaldifference = xpNextLevel - (100 * currentLevel * currentLevel);
    }

    void SetLvlText()
    {
        lvlText.text = "Lvl" + currentLevel.ToString();
    }
}
