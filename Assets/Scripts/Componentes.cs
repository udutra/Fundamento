using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Componentes : MonoBehaviour
{
    private SpriteRenderer sRenderer;
    public Color corSprite;
    public Material novoMaterial;

    void Start()
    {
        /*gameObject.name = "Nome do Objeto";
        print(gameObject.name);

        transform.position = new Vector3(10, 0, 0);
        transform.localScale = new Vector3(2,2,2);*/

        sRenderer = GetComponent<SpriteRenderer>();
        //sRenderer.color = new Color(255,0,0,255);
        sRenderer.color = corSprite;

        sRenderer.material = novoMaterial;

        sRenderer.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
