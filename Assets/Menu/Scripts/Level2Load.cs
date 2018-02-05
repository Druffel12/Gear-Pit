using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Load : MonoBehaviour
{
    public GameObject loadingImage;

    public void LoadLevel(string Level2)
    {
        SceneManager.LoadScene(Level2);
    }
}
