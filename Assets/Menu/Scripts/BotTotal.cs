using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotTotal : MonoBehaviour
{
    public Text BotTotalCount;
    public int Total;

    public void UpdateTotal()
    {
        Total++;
        BotTotalCount.text = Total.ToString();
        
    }

}
