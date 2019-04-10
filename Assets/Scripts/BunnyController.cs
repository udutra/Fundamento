﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyController : MonoBehaviour
{
    private GameController _GameController;
    private Rigidbody2D playerRb;
    public float forcaPulo;
    public Transform groundCheck;
    private bool grounded;

    private void Start()
    {
        _GameController = FindObjectOfType(typeof(GameController)) as GameController;
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, 0.02f);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && grounded == true)
        {
            playerRb.AddForce(new Vector2(0,forcaPulo));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Coletavel":
                {
                    Debug.Log("Entrou");
                    _GameController.Pontuar(10);
                    Destroy(collision.gameObject);
                    break;
                }
            case "Obstaculo":
                {
                    _GameController.MudarCena("GameOver");
                    break;
                }
            default:
                {
                    break;
                }
        }

        
    }
}
