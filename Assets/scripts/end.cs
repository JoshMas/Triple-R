using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class end : MonoBehaviour
{


    // Update is called once per frame
    public void LoadMenu()
    {
        SceneManager.LoadScene("menu");
    }
    public void QuitGame()
    {
        Debug.Log("quiting");
        Application.Quit();

    }




}
