using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject ball;
    public GameObject title;
    public GameObject startButton;
    private Tilt tilt;
    public int levelNumber = 1;

    private Text titleText;

    void Start()
    {
        ball.SetActive(false);

        //UI
        startButton.SetActive(true);
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
        tilt.turnontilt();
    }


    public void LevelComplete()
    { 
            title.SetActive(true);
            title.GetComponent<Text>().text = "Level "+ levelNumber+  " complete!";
            ball.SetActive(false);

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
