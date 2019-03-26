using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour
{
 
    public bool isFire;
    public float potencia;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //Responsável pela lógica do jogo

        /*if (Input.GetButton("Fire3"))
        {
            print("Estou segurando Fire 3");
        }*/

        if (Input.GetButtonDown("Fire3"))
        {
            isFire = true;
            potencia = 0;
            StartCoroutine("MegaTiro");
        }

        if (Input.GetButtonUp("Fire3"))
        {
            isFire = false;
            StopCoroutine("MegaTiro");
            print("Deu um tiro com potencia: " + potencia);
        }

        print(Input.GetAxis("Horizontal"));
        print(Input.GetAxisRaw("Fire1"));
    }
    
    IEnumerator MegaTiro()
    {
        yield return new WaitForSeconds(0.2f);
        potencia += 0.2f;
        if (isFire == true) 
        {
            StartCoroutine("MegaTiro");
        }
    }
}
