using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotValueHolder : MonoBehaviour {

    public int Bot11;
    public int Bot12;
    public int Bot13;
    public int Bot14;

    public int Bot21;
    public int Bot22;
    public int Bot23;
    public int Bot24;

    public GameObject BotType1;
    public GameObject BotType2;
    public GameObject BotType3;
    public GameObject BotType4;

    public void PopulateTeamArrays()
     {

        StaticBotList.team1 = new GameObject[Bot11 + Bot12 + Bot13 + Bot14];
        StaticBotList.team2 = new GameObject[Bot21 + Bot22 + Bot23 + Bot24];
        Debug.Log(StaticBotList.team1.Length);
        Debug.Log(Bot11);
        int i = 0;
        for (i = i; i < Bot11; ++i)
        {
            StaticBotList.team1[i] = BotType1;
        }
        for (i = i; i <Bot12 + Bot11; ++i)
        {
            StaticBotList.team1[i] = BotType2;
        }
        for (i = i; i <Bot13 + Bot12 + Bot11; ++i)
        {
            StaticBotList.team1[i] = BotType3;
        }
        for (i = i; i <Bot14 + Bot13 + Bot12 + Bot11; ++i)
        {
            StaticBotList.team1[i] = BotType4;
        }
        i = 0;
        for (i = i; i < Bot21; ++i)
        {
            StaticBotList.team2[i] = BotType1;
        }
        for (i = i; i < Bot22 + Bot21; ++i)
        {
            StaticBotList.team2[i] = BotType2;
        }
        for (i = i; i < Bot23 + Bot22 + Bot21; ++i)
        {
            StaticBotList.team2[i] = BotType3;
        }
        for (i = i; i < Bot24 + Bot23 + Bot22 + Bot21; ++i)
        {
            StaticBotList.team2[i] = BotType4;
        }
         
    }
        
    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(gameObject);  
    }
    public void UpdateTotal1()
    {
        Bot11++;
    }
    public void UpdateTotal2()
    {
        Bot12++;
    }
    public void UpdateTotal3()
    {
        Bot13++;    
    }
    public void UpdateTotal4()
    {
        Bot14++;
    }
    public void UpdateTotal5()
    {
        Bot21++;
    }
    public void UpdateTotal6()
    {
        Bot22++;
    }
    public void UpdateTotal7()
    {
        Bot23++;
    }
    public void UpdateTotal8()
    {
        Bot24++;
    }
    // Update is called once per frame
}	
