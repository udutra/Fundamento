using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fundamentos : MonoBehaviour
{
    public int diaSemana; // 0 = domingo
    public int contagem;
    public string comandos;
    public bool isFire;
    public float potencia;

    private void Awake()
    {
        
    }

    private void OnEnable()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        //Acontece imediatamente antes do primeiro frame do update
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

    private void FixedUpdate()
    {
        //taxa de atualização fixa. Padrão 20 milisegundos (Pode ser alterado)
        //Normalmente utilizado para comandos que envolvem física
    }

    // Update is called once per frame
    void Update()
    {
        //Responsável pela lógica do jogo

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


        /*if (Input.GetButton("Fire1"))
        {
            print("Estou segurando Fire 1");
        }*/

        if (Input.GetButtonDown("Fire1"))
        {
            isFire = true;
            potencia = 0;
            StartCoroutine("Megatiro");
        }

        if (Input.GetButtonUp("Fire1"))
        {
            isFire = false;
            StopCoroutine("MegaTiro");
            print("Deu um tiro com potencia: " + potencia);
        }

        
    }

    private void LateUpdate()
    {
        //Normalmente utilizado para controle de câmera, controle de animações, HUD
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

    /*IEnumerator MegaTiro()
    {
        yield return WaitForSeconds(0.2f);
        potencia += 0.2f;
        if (isFire == true) 
        {
            StartCoroutine("Megatiro");
        }
    }*/
}