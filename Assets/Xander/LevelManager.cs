using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



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

    private void Update()
    {
        bool team1alive = false;
        bool team2alive = false;
        foreach(GameObject o in team1)
        {
            if(o.activeSelf)
            {
                team1alive = true;
                break;
            }
        }
        foreach (GameObject o in team2)
        {
            if (o.activeSelf)
            {
                team2alive = true;
                break;
            }
        }

        //change to game over screen eventually
        if(!team1alive || !team2alive)
        {
            AsyncSceneLoader("MainMenu");
        }
    }

    private IEnumerator AsyncSceneLoader(string scene)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);

        while(!asyncLoad.isDone)
        {
            yield return null;
        }
    }

}
