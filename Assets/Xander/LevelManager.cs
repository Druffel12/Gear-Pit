using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    
    public Transform spawn1;
    public Transform spawn2;

    private GameObject[] team1;
    private GameObject[] team2;

    private void Start()
    {
        team1 = new GameObject[StaticBotList.team1.Length];
        team2 = new GameObject[StaticBotList.team2.Length];
        for(int i = 0; i < team2.Length; ++i)
        {
            GameObject bot = Instantiate(StaticBotList.team1[i]);
            bot.transform.position = spawn1.position;
        }
        for (int i = 0; i < team2.Length; ++i)
        {
            GameObject bot = Instantiate(StaticBotList.team2[i]);
            bot.transform.position = spawn2.position;
        }
    }

}
