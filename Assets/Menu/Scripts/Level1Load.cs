using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1Load : MonoBehaviour
{
    public GameObject loadingImage;

    public void LoadLevel(string Level1)
    {
        SceneManager.LoadScene(Level1);
    }
}
