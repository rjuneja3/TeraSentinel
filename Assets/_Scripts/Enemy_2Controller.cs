using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class Enemy_2Controller : MonoBehaviour
{
    public GameController gameController;

    [Header("Speed Values")]
    [SerializeField]
    public Speed horizontalSpeedRange;

    [SerializeField]
    public Speed verticalSpeedRange;

    public float horizontalSpeed;
    public float verticalSpeed;

    [SerializeField]
    public Boundary boundary;
    // Start is called before the first frame update.
    void Start()
    {
        Reset();
    }
    // Update is called once per frame.
    void Update()
    {
        Move();
        BoundaryCheck();
    }
    void Move()
    {
        Vector2 newPosition = new Vector2(horizontalSpeed, verticalSpeed);
        Vector2 currentPosition = transform.position;
        currentPosition -= newPosition;
        transform.position = currentPosition;
    }
    void Reset()
    {
        horizontalSpeed = Random.Range(horizontalSpeedRange.min, horizontalSpeedRange.max);
        verticalSpeed = Random.Range(verticalSpeedRange.min, verticalSpeedRange.max);
        float randomYPosition = Random.Range(boundary.Bottom, boundary.Top);
        transform.position = new Vector2(boundary.Right, randomYPosition);
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
                Vector2 newPosition = new Vector2(5, 0);
                Vector2 currentPosition = transform.position;
                currentPosition += newPosition;
                transform.position = currentPosition;
                break;
        }
    }
}
