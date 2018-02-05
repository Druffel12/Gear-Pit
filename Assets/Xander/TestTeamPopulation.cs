using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTeamPopulation : MonoBehaviour {

    public GameObject bot;

	// Use this for initialization
	void Start () {
        StaticBotList.team1 = new GameObject[1];
        StaticBotList.team1[0] = bot;
        StaticBotList.team2 = new GameObject[1];
        StaticBotList.team2[0] = bot;
    }
	
}
