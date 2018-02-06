using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotTotal : MonoBehaviour
{
    public Text BotTotalCount;
    public int Total;
    BotValueHolder Values;

    void Start ()
    {
        Values = FindObjectOfType<BotValueHolder>();
    }
    public void UpdateTotal()
    {
        Total++;
        BotTotalCount.text = Total.ToString();
        
    }

}
