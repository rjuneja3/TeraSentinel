using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class PlayerController : MonoBehaviour
{
    public Speed speed;
    public Boundary boundary;
    public GameController gameController;
    public GameObject Bullet;
    Vector2 bullPos2;
    Vector2 bullPos1;
    public float RoF = 0.5f;
    float FireNext = 0f;
    //
    private AudioSource _hit;
    private AudioSource _shot;
    //
    // Start is called before the first frame update
    void Start()
    {
        _hit = gameController.audioSources[(int)SFX.PLAYERGOTHIT];
        _shot = gameController.audioSources[(int)SFX.PLAYERSHOT];
    }
    // Update is called once per frame
    void Update()
    {
        Move();
        BoundaryCheck();       
    }

    public void Move()
    {
        Vector2 newPosition = transform.position;
        if (Input.GetAxisRaw("Vertical") > 0.0f)
        {
            newPosition += new Vector2(0.0f, speed.max); 
        }
        if (Input.GetAxisRaw("Vertical") < 0.0f)
        {
            newPosition += new Vector2(0.0f, speed.min);
        }
        transform.position = newPosition;
        if (Input.GetButton("Fire1") && Time.time > FireNext)
        {
            FireNext = Time.time + RoF;
            Fire();
        }
    }

    public void BoundaryCheck()
    {
        if (transform.position.y > boundary.Top)
        {
            transform.position = new Vector2(transform.position.x, boundary.Top);
        }
        if (transform.position.y < boundary.Bottom)
        {
            transform.position = new Vector2(transform.position.x, boundary.Bottom);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Enemy1":                
                gameController.Health -= 10;        _hit.Play();
                break;
            case "Enemy2":                
                gameController.Health -= 15;
                break;
            case "Boss":
                gameController.Health -= 50;
                _hit.Play();
                break;
            case "BossMissile":
                gameController.Health -= 30;
                _hit.Play();
                break;
        }
    }

    void Fire()
    {        
        bullPos1 = transform.position;
        bullPos2 = transform.position;
        bullPos1 += new Vector2(0.75f, +0.1f);
        bullPos2 += new Vector2(0.75f, -0.1f);
        Instantiate(Bullet, bullPos1, transform.rotation * Quaternion.Euler(0f, 0f, 0f));
        Instantiate(Bullet, bullPos2, transform.rotation * Quaternion.Euler(0f, 0f, 0f));
        _shot.Play();
    }
}
