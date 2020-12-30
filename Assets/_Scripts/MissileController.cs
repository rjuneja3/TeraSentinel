using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;
using UnityEngine.SceneManagement;

public class MissileController : MonoBehaviour
{
    public GameController gameController;
    public float Hv = 0.5f;
    public float speed = 5f;
    public Boundary boundary;
    public Transform target;
    void Start()
    {
        
    }
    void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Move();
        BCheck();
    }
    void Move()
    {
        //feel free to change the speed and the space on where the missile 
        //follows the player and the missile reads this spot from the player as its point
        if (5 < Vector2.Distance(transform.position, target.position) && Vector2.Distance(transform.position, target.position) < 9)
        {

            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        }
        else
        {
            Vector2 newPos = new Vector2(Hv, 0.0f);
            Vector2 curPos = transform.position;
            curPos -= newPos;
            transform.position = curPos;
        }
    }
    void BCheck()
    {
        if (transform.position.x <= boundary.Left)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Player":
                Destroy(gameObject);
                break;
        }
    }
}
