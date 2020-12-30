using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndController : MonoBehaviour
{
    public GameObject startButton;
    public GameObject quitButton;
    public Text finalScoreLabel;

    void Start()
    {
        finalScoreLabel.text = "Score: " + PlayerPrefs.GetInt("FScore").ToString();
    }
    public void OnClickStart()
    {
        SceneManager.LoadScene(1);
    }
    public void OnClickQuit()
    {
        Application.Quit();
    }
}
