using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject ball;
    public GameObject title;
    public GameObject complete;
    public GameObject startButton;
    public GameObject BG;
    public GameObject gameOverPanel;
    public GameObject lives;
    public GameObject lives1;
    public GameObject lives2;
    public GameObject lives3;
    private Tilt tilt;
    public int levelNumber = 1;

    private Text titleText;

    void Start()
    {
        ball.SetActive(false);

        //UI
        startButton.SetActive(true);
        complete.SetActive(false);
        gameOverPanel.SetActive(false);
        lives.SetActive(false);
        title.SetActive(true);
        tilt = GameObject.Find("Platform").GetComponent<Tilt>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        ball.SetActive(true);
        startButton.SetActive(false);
        title.SetActive(false);
        lives.SetActive(true);
        lives3.SetActive(true);
        tilt.turnontilt();
        BG.SetActive(false);
    }
    public void Restart()
    {
        SceneManager.LoadScene("Level_1");
    }
    public void Quit()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif 
    }

    public void LevelComplete()
    { 
            complete.SetActive(true);
            ball.SetActive(false);
            lives.SetActive(false);
            lives1.SetActive(false);
            lives2.SetActive(false);
            lives3.SetActive(false);

        if (levelNumber < 3)
        {
            StartCoroutine(LoadLevelWithDelay(levelNumber + 1));
        }
        else
        {
            StartCoroutine(LoadLevelWithDelay(1)); // Back to level 1
        }

    }

    public IEnumerator LoadLevelWithDelay(int levelNo)
    {
        yield return new WaitForSeconds(2.0f);

        SceneManager.LoadScene("Level_" + levelNo); // opens new scene
    }
}
