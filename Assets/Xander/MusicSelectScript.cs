using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSelectScript : MonoBehaviour {

    public AudioClip[] tracks;
    public string[] trackNames;

    public Text trackText;

    private void Start()
    {
        trackText.text = trackNames[StaticBotList.trackNum];
        StaticBotList.levelMusic = tracks[StaticBotList.trackNum];
    }

    public void NextTrack()
    {
        ++StaticBotList.trackNum;
        if(StaticBotList.trackNum >= tracks.Length)
        {
            StaticBotList.trackNum = 0;
        }
        trackText.text = trackNames[StaticBotList.trackNum];
        StaticBotList.levelMusic = tracks[StaticBotList.trackNum];
    }

    public void PrevTrack()
    {
        --StaticBotList.trackNum;
        if (StaticBotList.trackNum < 0)
        {
            StaticBotList.trackNum = tracks.Length - 1;
        }
        trackText.text = trackNames[StaticBotList.trackNum];
        StaticBotList.levelMusic = tracks[StaticBotList.trackNum];
    }

}
