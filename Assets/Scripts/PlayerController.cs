using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameController _GameController;
    private Rigidbody2D playerRb;

    private void Start()
    {
        _GameController = FindObjectOfType(typeof(GameController)) as GameController;
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        float posX = transform.position.x;
        float posY = transform.position.y;

        playerRb.velocity = new Vector2(horizontal * _GameController.velocidadeMovimento, vertical * _GameController.velocidadeMovimento);

        //Verificar limite X
        if (transform.position.x > _GameController.limiteMaxX)
        {
            posX = _GameController.limiteMaxX;
        }
        else if (transform.position.x < _GameController.limiteMinX)
        {
            posX = _GameController.limiteMinX;
        }


        //Verificar limite Y
        if (transform.position.y > _GameController.limiteMaxY)
        {
            posY = _GameController.limiteMaxY;
        }
        else if(transform.position.y < _GameController.limiteMinY)
        {
            posY = _GameController.limiteMinY;
        }

        transform.position = new Vector3(posX, posY, 0);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _GameController.MudarCena("GameOver");
    }
}
