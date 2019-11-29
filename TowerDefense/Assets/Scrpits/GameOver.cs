using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text wavesText;
   
    void OnEnable()
    {
        wavesText.text = PlayerStats.waves.ToString();
    }

    public void Retry()
    {
        // used to load a scene, the "main scene" can ben either with exact name or with number "0" SceneManager.LoadScene("MainScene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
