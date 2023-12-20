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
    public GameObject spawn;
    private Tilt tilt;
    public int levelNumber = 1;
    private float lifepoints = 3;

    private Text titleText;

    void Start()
    {
        ball.SetActive(false);
        spawn = GameObject.Find("spawn");
        spawn.transform.position = ball.transform.position; 

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

    public void takeawayhealth()
    {
        ball.transform.position = spawn.transform.position;
        lifepoints = lifepoints - 1;
        
        updatehealth();
    }
    public void updatehealth()
    {
        if (lifepoints == 3) { lives3.SetActive(true); }
        else if (lifepoints == 2) { lives2.SetActive(true);
            lives3.SetActive(false);
        }
        else if (lifepoints == 1) { lives1.SetActive(true);
            lives2.SetActive(false);
        }
        else { StartCoroutine(LoadLevelWithDelay(1)); }
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
        yield return new WaitForSeconds(0f);

        SceneManager.LoadScene("Level_" + levelNo); // opens new scene
    }
}
