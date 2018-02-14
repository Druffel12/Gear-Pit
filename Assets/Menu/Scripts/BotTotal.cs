using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotTotal : MonoBehaviour
{
    public Text BotTotalCount;
    public int Total;
    BotValueHolder Values;
    public Button dummy;
    void Start ()
    {
        Values = FindObjectOfType<BotValueHolder>();
    }
    public void UpdateTotal(int amt = 1)
    {
        Total += amt;
        BotTotalCount.text = Total.ToString();
        dummy.Select();
    }
 

}
