using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss2Controller : MonoBehaviour
{
    public GameController gameController;
    public GameObject Missile;
    Vector2 mslePos1;
    Vector2 mslePos2;
    public int BossHealth;
    public float rateOfFire = .5f;
    public float NextFire = 0f;
    public float msleSpeed = .5f;
    void Start()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        if (scene == 1)
        {
            BossHealth = 125;
        }
        if (scene == 3)
        {
            BossHealth = 250;
        }
        if (scene == 5)
        {
            BossHealth = 500;
        }
    }
    void Update()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        if (Time.time > NextFire)
        {
            NextFire = Time.time + rateOfFire;
            Fire();
        }
        if (BossHealth < 1)
        {
            if (scene == 1)
            {
                SceneManager.LoadScene(2);
            }
            if (scene == 3)
            {
                SceneManager.LoadScene(4);
            }
            if (scene == 5)
            {
                SceneManager.LoadScene(6);
            }
        }
    }
    void Fire()
    {
        mslePos1 = transform.position;
        mslePos2 = transform.position;
        mslePos1 += new Vector2(-0.75f, +0.2f);
        mslePos2 += new Vector2(-0.75f, -0.2f);
        Instantiate(Missile, mslePos1, transform.rotation);
        Instantiate(Missile,
          mslePos2, transform.rotation);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Bullet":
                BossHealth -= 5;
                break;
        }
    }
}
