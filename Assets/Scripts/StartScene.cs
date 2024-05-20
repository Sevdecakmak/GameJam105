using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public int changeScene;

    public void startScene()
    {
        SceneManager.LoadScene(changeScene);
    }

    public void quitScene()
    {
        Application.Quit();
        Debug.Log("it's working");
    }
}
