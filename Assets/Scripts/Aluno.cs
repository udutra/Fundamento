using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aluno : MonoBehaviour
{

    //modificador   tipo        nome;
    public          string      nomeAluno;
    public          int         idadeAluno;
    private          bool       isAprovado;
    public          float       mediaBimestreA;
    public          float       mediaBimestreB;
    public          float       mediaBimestreC;
    public          float       mediaBimestreD;
    public          float       mediaFinal;

    //Modificadores de acesso
    //public - O acesso não é restrito
    //private

    //internal
    //protected
    //protected internal
    //private protected


    private void Start()
    {
        if (mediaFinal >= 7)
        {
            print("A média final é maior ou igual a 7");
        }
        else if (mediaFinal >= 5)
        {
            print("A média final é maior ou igual a 5");
        }
        else if (mediaFinal >= 3) {
            print("A média final é maior ou igual a 3");
        }
        else
        {
            print("A média final é menor que 3");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("Apertei a tecla Espaço");
            CalcularMediaFinal();
        }
    }

    public void CalcularMediaFinal()
    {
        mediaFinal = (mediaBimestreA + mediaBimestreB + mediaBimestreC + mediaBimestreD) / 4;
        print(mediaFinal);
    }
}