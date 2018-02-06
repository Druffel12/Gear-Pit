using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTeamPopulation : MonoBehaviour {

    public GameObject bot;

	// Use this for initialization
	void Start () {
        StaticBotList.team1 = new GameObject[5];
        for(int i = 0; i < StaticBotList.team1.Length; ++i)
        {
            StaticBotList.team1[i] = bot;
        }
        StaticBotList.team2 = new GameObject[5];
        for (int i = 0; i < StaticBotList.team2.Length; ++i)
        {
            StaticBotList.team2[i] = bot;
        }
    }
	
}
