using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fundamentos : MonoBehaviour
{
    public int diaSemana; // 0 = domingo
    public int contagem;
    public string comandos;


    // Start is called before the first frame update
    void Start()
    {
        EscreverDiaSemana();
        while (contagem < 100)
        {
            print(contagem);
            contagem += 1;
        }

        for (int i = 0; i < 100; i++)
        {
            print(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            comandos += "E";
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            comandos += "D";
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            comandos += "C";
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            comandos += "B";
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ExecutaComando();
        }

        

    }

    private void ExecutaComando()
    {
        switch (comandos)
        {
            case "BD":
                {
                    print("Hadouken");
                    break;
                }
            case "DBD":
                {
                    print("Shoryuken");
                    break;
                }
            default:
                {
                    break;
                }
        }
        comandos = "";
    }

    private void EscreverDiaSemana()
    {
        EscreverDiaSemana(diaSemana);
    }

    private void EscreverDiaSemana(int d)
    {
        switch (d)
        {
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