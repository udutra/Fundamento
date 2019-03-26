using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrilComFisica : MonoBehaviour
{

    public float velocidade;
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = 1 * velocidade;
        rb.velocity = new Vector2(x, 0);
    }
}
