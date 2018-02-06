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
    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(gameObject);  
    }
    public void UpdateTotal1()
    {
        Bot11++;
        Team1[] = Bot11; 
    }
    public void UpdateTotal2()
    {
        Bot12++;
        Bot12; 
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
