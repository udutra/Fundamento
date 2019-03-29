using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D playerRb;
    public float velocidadeMovimento, limiteMaxX, limiteMinX, limiteMaxY, limiteMinY;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        float posX = transform.position.x;
        float posY = transform.position.y;

        playerRb.velocity = new Vector2(horizontal * velocidadeMovimento, vertical * velocidadeMovimento);

        //Verificar limite X
        if (transform.position.x > limiteMaxX)
        {
            posX = limiteMaxX;
        }
        else if (transform.position.x < limiteMinX)
        {
            posX = limiteMinX;
        }


        //Verificar limite Y
        if (transform.position.y > limiteMaxY)
        {
            posY = limiteMaxY;
        }
        else if(transform.position.y < limiteMinY)
        {
            posY = limiteMinY;
        }

        transform.position = new Vector3(posX, posY, 0);

    }
}
