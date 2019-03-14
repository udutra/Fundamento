using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fundamentos : MonoBehaviour
{
    public int diaSemana; // 0 = domingo


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EscreverDiaSemana();
        }
    }

    private void EscreverDiaSemana()
    {
        switch (diaSemana){
            case 0:
                {
                    print("Domingo");
                    break;
                }
            case 1:
                {
                    print("Segunda-feira");
                    break;
                }
            case 2:
                {
                    print("Terça-feira");
                    break;
                }
            case 3:
                {
                    print("Quarta-feira");
                    break;
                }
            case 4:
                {
                    print("Quinta-feira");
                    break;
                }
            case 5:
                {
                    print("Sexta-feira");
                    break;
                }
            case 6:
                {
                    print("Sabado-feira");
                    break;
                }
            default:
                {
                    print("Dia da semana inváido");
                    break;
                }
        }
    }
}