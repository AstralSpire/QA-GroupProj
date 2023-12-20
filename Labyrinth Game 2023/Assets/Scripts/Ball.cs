using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update

    private GameController gameCont;
    private int livesNum = 3;


    void Start()
    {
        gameCont = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (livesNum == 0)
        {
            SceneManager.LoadScene("Level_1");
        }
        if (this.gameObject.transform.position.y < -10)
        {
            gameCont.takeawayhealth();

        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name == "Goal")
        {
            gameCont.LevelComplete();
        }


    }
}
