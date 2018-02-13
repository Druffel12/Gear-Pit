using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class LevelManager : MonoBehaviour {

    public float spawnRadius = 5f;

    public Transform spawn1;
    public Transform spawn2;

    public bool testSpawn = false;
    public GameObject testBot;
    public GameObject testBot2;

    private GameObject[] team1;
    private GameObject[] team2;

    private void Start()
    {
        StraferHivemindList.minds[0] = new StraferHivemind();
        StraferHivemindList.minds[0].team = 1;
        StraferHivemindList.minds[1] = new StraferHivemind();
        StraferHivemindList.minds[1].team = 2;

        if (!testSpawn)
        {
            team1 = new GameObject[StaticBotList.team1.Length];
            team2 = new GameObject[StaticBotList.team2.Length];
            
            for (int i = 0; i < team1.Length; ++i)
            {
                GameObject bot = Instantiate(StaticBotList.team1[i]);
                Vector2 spawnPos = Random.insideUnitCircle * spawnRadius;
                bot.transform.position = new Vector3(spawn1.position.x + spawnPos.x,
                                                     spawn1.position.y,
                                                     spawn1.position.z + spawnPos.y);
                bot.GetComponent<Battlebot>().team = 1;
                team1[i] = bot;
            }
            for (int i = 0; i < team2.Length; ++i)
            {
                GameObject bot = Instantiate(StaticBotList.team2[i]);
                Vector2 spawnPos = Random.insideUnitCircle * spawnRadius;
                bot.transform.position = new Vector3(spawn2.position.x + spawnPos.x,
                                                     spawn2.position.y,
                                                     spawn2.position.z + spawnPos.y);
                bot.GetComponent<Battlebot>().team = 2;
                team2[i] = bot;
            }
        }
        else
        {
            team1 = new GameObject[15];
            team2 = new GameObject[15];
            for (int i = 0; i < team1.Length; ++i)
            {
                GameObject bot = Instantiate(testBot);
                Vector2 spawnPos = Random.insideUnitCircle * spawnRadius;
                bot.transform.position = new Vector3(spawn1.position.x + spawnPos.x,
                                                     spawn1.position.y,
                                                     spawn1.position.z + spawnPos.y);
                bot.GetComponent<Battlebot>().team = 1;
                team1[i] = bot;
            }
            for (int i = 0; i < team2.Length; ++i)
            {
                GameObject bot = Instantiate(testBot2);
                Vector2 spawnPos = Random.insideUnitCircle * spawnRadius;
                bot.transform.position = new Vector3(spawn2.position.x + spawnPos.x,
                                                     spawn2.position.y,
                                                     spawn2.position.z + spawnPos.y);
                bot.GetComponent<Battlebot>().team = 2;
                team2[i] = bot;
            }
        }
    }

    private void Update()
    {
        bool team1alive = false;
        bool team2alive = false;
        foreach(GameObject o in team1)
        {
            if(o.activeInHierarchy)
            {
                team1alive = true;
                break;
            }
        }
        foreach (GameObject o in team2)
        {
            if (o.activeInHierarchy)
            {
                team2alive = true;
                break;
            }
        }

        foreach(StraferHivemind m in StraferHivemindList.minds)
        {
            m.Update(this);
        }
        
        //change to game over screen eventually
        if(!team1alive || !team2alive)
        {
            Invoke("LoadFromInvoke", 3f);
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void LoadFromInvoke()
    {
        StartCoroutine(AsyncSceneLoader("MainMenu"));
    }

    private IEnumerator AsyncSceneLoader(string scene)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);

        while(!asyncLoad.isDone)
        {
            yield return null;
        }
    }



    public Transform FindClosestBotTo(Vector3 pos, int team, string type = "")
    {
        Transform closestEnemy = null;
        if(team == 1)
        {
            foreach (GameObject b in team1)
            {
                if (closestEnemy == null && b.activeInHierarchy
                    && (type == "" || b.name == type))
                {
                    closestEnemy = b.transform;
                }
                else if (closestEnemy != null && b.activeInHierarchy
                         && (type == "" || b.name == type) &&
                         Vector3.Distance(b.transform.position, pos) <
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
                if (closestEnemy == null && b.activeInHierarchy
                    && (type == "" || b.name == type))
                {
                    closestEnemy = b.transform;
                }
                else if (closestEnemy != null && b.activeInHierarchy
                         && (type == "" || b.name == type) &&
                         Vector3.Distance(b.transform.position, pos) <
                         Vector3.Distance(closestEnemy.position, pos))
                {
                    closestEnemy = b.transform;
                }
            }
        }

        return closestEnemy;
    }



}
