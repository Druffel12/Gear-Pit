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
            bot.GetComponent<Battlebot>().team = 1;
            team1[i] = bot;
        }
        for (int i = 0; i < team2.Length; ++i)
        {
            GameObject bot = Instantiate(StaticBotList.team2[i]);
            bot.transform.position = spawn2.position;
            bot.GetComponent<Battlebot>().team = 2;
            team2[i] = bot;
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



    public Transform FindClosestBotTo(Vector3 pos, int team)
    {
        Transform closestEnemy = null;
        if(team == 1)
        {
            foreach (GameObject b in team1)
            {
                if (closestEnemy == null)
                {
                    closestEnemy = b.transform;
                }
                else if (Vector3.Distance(b.transform.position, pos) <
                         Vector3.Distance(closestEnemy.position, pos))
                {
                    closestEnemy = b.transform;
                }
            }
        }
        else
        {
            foreach (GameObject b in team2)
            {
                if (closestEnemy == null)
                {
                    closestEnemy = b.transform;
                }
                else if (Vector3.Distance(b.transform.position, pos) <
                         Vector3.Distance(closestEnemy.position, pos))
                {
                    closestEnemy = b.transform;
                }
            }
        }

        return closestEnemy;
    }



}
