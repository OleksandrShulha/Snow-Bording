using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayrControl : MonoBehaviour
{

    Rigidbody2D rb2d;
    [SerializeField] float tourgeAmount = 20f;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
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
}
