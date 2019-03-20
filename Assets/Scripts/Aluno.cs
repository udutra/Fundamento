using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aluno : MonoBehaviour
{

    //modificador       tipo        nome;
    public              string      nomeAluno;
    public              int         idadeAluno;
    private             bool        isAprovado;
    /*public              float       mediaBimestreA;
    public              float       mediaBimestreB;
    public              float       mediaBimestreC;
    public              float       mediaBimestreD;*/
    public              int         frequencia;
    public              float       mediaNecessaria;
    public              int         frequenciaNecessaria;

    public              float[]       mediaBimestral;
    

    //Modificadores de acesso
    //public - O acesso não é restrito
    //private

    //internal
    //protected
    //protected internal
    //private protected


    private void Start()
    {
        CalcularMediaFinal();
        if (VerificaAprovacaoAluno(7) == true)
        {
            print("Está aprovado");
        }
        else
        {
            print("Está Reprovado");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CalcularMediaFinal();
        }
    }

    public void CalcularMediaFinal()
    {
        //float mediaFinal = (mediaBimestreA + mediaBimestreB + mediaBimestreC + mediaBimestreD) / 4;
        float mediaFinal = MediaFinal();

        if(frequencia >= frequenciaNecessaria && mediaFinal >= mediaNecessaria)
        {
            print("O aluno " + nomeAluno + " foi aprovado com média: " + mediaFinal + " e frequência de " + frequencia + "%");
            isAprovado = true;
        }
        else
        {
            isAprovado = false;
            
            //EXERCÍCIO - INDIQUE O MOTIVO DA REPROVAÇÃO

            if(frequencia < frequenciaNecessaria && mediaFinal < mediaNecessaria)
            {
                print("O aluno " + nomeAluno + " foi reprovado pela média: " + mediaFinal + "/" + mediaNecessaria + " e também pela frequência de " + frequencia + "%/" + frequenciaNecessaria + "%");
            }
            else if(mediaFinal < mediaNecessaria){
                print("O aluno " + nomeAluno + " foi reprovado pela média: " + mediaFinal + "/" + mediaNecessaria);
            }
            else
            {
                print("O aluno " + nomeAluno + " foi reprovado pela frequência: " + frequencia + "%/" + frequenciaNecessaria + "%");
            }

        }

    }

    public bool VerificaAprovacaoAluno(float media)
    {
        bool isAprovado2;

        if (media >= mediaNecessaria)
        {
            isAprovado2 =  true;
        }
        else
        {
            isAprovado2 = false;
        }

        return isAprovado2;
    }

    private float MediaFinal()
    {
        float media = (mediaBimestral[0] + mediaBimestral[1] + mediaBimestral[2] + mediaBimestral[4]) / 4;
        return media;
    }
}