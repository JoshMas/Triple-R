using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    // Start is called before the first frame update
    public void Playgame()
    {
        SceneManager.LoadScene("TopDown");
    }
    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }

}


