using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{    
    //The timer code is retrived from:
    //https://www.noob-programmer.com/unity3d/countdown-timer/     
    [Header("Objects")]
    public GameObject Enemy_1;
    public GameObject Enemy_2;
    public GameObject Boss1;
    public GameObject Boss2;
    public GameObject Boss3;
    public int Enemy_1Num;
    public int Enemy_2Num;
    public List<GameObject> E1list;
    public List<GameObject> E2list;
    bool end = false;
    bool timerstop = false;

    [Header("Enemey Properties")]
    public int _e1health;
    public int _e2health;

    [Header("Scoreboard")]
    [SerializeField]
    private int _health;
    [SerializeField]
    private int _timer;

    [Header("Audio Sources")]
    public SFX activeSFX;
    public AudioSource[] audioSources;

    public Text healthLabel;
    public Text timeLabel;

    public int TimeLeft = 500;
     
    public int Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
            healthLabel.text = "Health: " + Health.ToString();
        }
    }
    public int Timer
    {       
        get
        {
            return _timer;
        }
        set
        {            
            _timer = value;
            timeLabel.text = "Time: " + Timer.ToString();
        }
    }
    public int E1Health
    {
        get { return _e1health; }
        set { _e1health = value; }
    }
    public int E2Health
    {
        get { return _e2health; }
        set { _e2health = value; }
    }
    void Start()
    {
        StartCoroutine("CountDown");
        UnityEngine.Time.timeScale = 1;        
        int currScene = SceneManager.GetActiveScene().buildIndex;
        Health = 100;
        Timer = 100;
        if (currScene == 1)
        {
            Timer = 70;
        }else if(currScene == 3)
        {
            Timer = 120;
        }else if(currScene == 5)
        {
            Timer = 150;
        }
        E1list = new List<GameObject>();
        E2list = new List<GameObject>();
        EnemySpawn();
    }
    void EnemySpawn()
    {
        if (timerstop == false)
        {
            for (int e1num = 0; e1num < Enemy_1Num; e1num++)
            {
                E1list.Add(Instantiate(Enemy_1));
            }
            for (int e2num = 0; e2num < Enemy_2Num; e2num++)
            {
                E2list.Add(Instantiate(Enemy_2));
            }
        }
    }
    void Update()
    {        
        int currScene = SceneManager.GetActiveScene().buildIndex;
        Timer = TimeLeft;
        if(Timer < 1)
        {
            timerstop = true;
            if (currScene == 1 && end == false)
            {                
                Instantiate(Boss1);                
                end = true;
            }
            if (currScene == 3 && end == false)
            {
                Instantiate(Boss2);                
                end = true;
            }
            if (currScene == 5 && end == false)
            {
                Instantiate(Boss3);                
                end = true;
            }
        }
        if (Health < 1)
        {
            SceneManager.LoadScene(6);
        }
        PlayerPrefs.SetInt("FScore", Timer);                
    }
    IEnumerator CountDown()
    {        
        while (timerstop == false)
        {
            yield return new WaitForSeconds(1);
            TimeLeft--;
        }
    }
}
