﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{

    public GameObject loadingImage;

    public void LoadLevel(string LevelSelect)
    {
        SceneManager.LoadScene(LevelSelect);
    }
}
