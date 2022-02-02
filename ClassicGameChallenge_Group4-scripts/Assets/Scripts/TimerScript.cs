using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public Text healthtxt;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Player1.HP > 0)
        {
            Player1.HP -= Time.deltaTime;
        }
        else
        {
            Player1.HP = 0;
        }
        ShowTime(Player1.HP);

    }
    void ShowTime(float amountToShow)
    {
        if (amountToShow < 0)
        {
            amountToShow = 0;
        }


        float minutes = Mathf.FloorToInt(amountToShow / 60);

        healthtxt.text = Player1.HP.ToString("f0");
    }
}