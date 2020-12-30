using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class Enemy_1Controller : MonoBehaviour
{
    public float horizontalSpeed = 0.05f;
    public Boundary boundary;
    public GameController gameController;
    void Start()
    {
        Reset();        
    }
    void Update()
    {
        Move();
        BoundaryCheck();
    }
    void Move()
    {
        Vector2 newPosition = new Vector2(horizontalSpeed, 0.0f);
        Vector2 currentPosition = transform.position;
        currentPosition -= newPosition;
        transform.position = currentPosition;
    }

    void Reset()
    {
        float randomYPosition = Random.Range(boundary.Bottom, boundary.Top);
        transform.position = new Vector2(Random.Range(boundary.Right, boundary.Right + 2.0f), randomYPosition);
    }
    void BoundaryCheck()
    {
        if (transform.position.x <= boundary.Left)
        {
            Reset();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {        
        switch (other.gameObject.tag)
        {
            case "Player":
                Reset();
                break;
            case "Bullet":
                Reset();
                break;
        }
    }
}
