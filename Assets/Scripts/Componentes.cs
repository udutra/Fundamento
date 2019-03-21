using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Componentes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "Nome do Objeto";
        print(gameObject.name);

        transform.position = new Vector3(10, 0, 0);
        transform.localScale = new Vector3(2,2,2);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
