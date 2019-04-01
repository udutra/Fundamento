using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrilController : MonoBehaviour
{
    private GameController _GameController;
    private Rigidbody2D barrilRb;
    private bool pontuado;

    private void Start()
    {
        _GameController = FindObjectOfType(typeof(GameController)) as GameController;
        barrilRb = GetComponent<Rigidbody2D>();
        barrilRb.velocity = new Vector2(_GameController.velocidadePlataforma, 0);
    }

    private void Update()
    {
        if (transform.position.x < _GameController.distanciaDestruir)
        {
            Destroy(this.gameObject);
        }
    }

    private void LateUpdate()
    {
        if(pontuado == false)
        {
            if(transform.position.x < _GameController.posXPlayer)
            {
                pontuado = true;
                _GameController.Pontuar(150);
            }
        }
    }
}
