using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class BulletController : MonoBehaviour
{
    public GameController gameController;
    public Boundary boundary;
    public float horV = 5f;
    Rigidbody2D rb;
    public BulletState bulletState;
    public Animator bulletAnimator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bulletState = BulletState.SHOT;
        bulletAnimator.SetInteger("BulletState", (int)BulletState.SHOT);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(horV, 0);
        if (rb.position.x > 6.9f)
        {
            Destroy(gameObject);
        }
        if (rb.position.x > -5 && rb.position.x > -5)
        {
            bulletState = BulletState.INAIR;
            bulletAnimator.SetInteger("BulletState", (int)BulletState.INAIR);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Enemy1":
                bulletState = BulletState.HIT;
                bulletAnimator.SetInteger("BulletState", (int)BulletState.HIT);
                Destroy(gameObject);                
                break;
            case "Enemy2":
                bulletState = BulletState.HIT;
                bulletAnimator.SetInteger("BulletState", (int)BulletState.HIT);
                Destroy(gameObject);
                break;
            case "Boss":
                bulletState = BulletState.HIT;
                bulletAnimator.SetInteger("BulletState", (int)BulletState.HIT);
                Destroy(gameObject);
                break;
        }
    }
}
