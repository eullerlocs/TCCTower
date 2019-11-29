using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;

    public GameObject gameOverUI;

    void Start()
    {
        GameIsOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameIsOver)
            return;

        if (PlayerStats.Health <= 0)
        {
            EndGame();
        }

        //types of input keys for normal key and for keycodes
        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }

        void EndGame()
        {
            GameIsOver = true;
            gameOverUI.SetActive(true);

        }
    }
}
