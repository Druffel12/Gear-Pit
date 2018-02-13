using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Quit : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.None; 
    }
    void Update() { }
    public void Exit()
    {
        Application.Quit();
    }
}

