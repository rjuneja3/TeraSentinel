using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public float horizontalSpeed = 0.02f;
    public float resetFromPos = 2.21f;
    public float resetToPos = -2.21f;
    // Start is called before the first frame update
    void Start()
    {
        //Reset();
    }

    // Update is called once per frame
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
        transform.position = new Vector2(resetFromPos, 0.0f);
    }

    void BoundaryCheck()
    {
        if (transform.position.x <= resetToPos)
        {
            Reset();
        }
    }
}
