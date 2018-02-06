using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public GameObject loadingImage;


    public void LoadLevelSelect(string LevelSelect)
    {
        SceneManager.LoadScene(LevelSelect);  
    }
}
