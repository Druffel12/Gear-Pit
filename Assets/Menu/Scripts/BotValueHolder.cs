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
    public void UpdateTotal1(int amt = 1)
    {
        Bot11 += amt;
    }
    public void UpdateTotal2(int amt = 1)
    {
        Bot12 += amt;
    }
    public void UpdateTotal3(int amt = 1)
    {
        Bot13 += amt;    
    }
    public void UpdateTotal4(int amt = 1)
    {
        Bot14 += amt;
    }
    public void UpdateTotal5(int amt = 1)
    {
        Bot21 += amt;
    }
    public void UpdateTotal6(int amt = 1)
    {
        Bot22 += amt;
    }
    public void UpdateTotal7(int amt = 1)
    {
        Bot23 += amt;
    }
    public void UpdateTotal8(int amt = 1)
    {
        Bot24 += amt;
    }
    // Update is called once per frame
}	
