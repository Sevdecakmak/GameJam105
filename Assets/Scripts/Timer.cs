using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] public float remainingTime;
    //public GameObject gameOverText;

    public string levelToLoad;

    // Update is called once per frame
    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime <= 0)
        {
            //distance and gameoverscene


            remainingTime = 0;
            //Application.LoadLevel(levelToLoad);
            SceneManager.LoadScene(levelToLoad);

            //oyun bitti
            timerText.color = Color.red;
            // gameOverText.SetActive(true);

        }

        timerText.text = remainingTime.ToString();
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void AddTime(float amount)
    {
        remainingTime += amount;
    }

    public void SubractTime(float amount)
    {
        remainingTime -= amount;
    }

}
