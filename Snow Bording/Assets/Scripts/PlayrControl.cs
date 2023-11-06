using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayrControl : MonoBehaviour
{

    Rigidbody2D rb2d;
    [SerializeField] float tourgeAmount = 20f;
    SurfaceEffector2D surfaceEffector2D;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 12f;
    [SerializeField] ParticleSystem snowEfect;
    bool canMove = true;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindAnyObjectByType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            MovePlayr();
        }

        SpeedControl();
    }

    public void DisableMove()
    {
        canMove = false;
        Debug.Log("Not Move");
    }

    private void SpeedControl()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }

    private void MovePlayr()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(tourgeAmount);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-tourgeAmount);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            snowEfect.Play();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            snowEfect.Stop();
        }
    }
}
