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
    public              int         op;
    public              float[]     mediaBimestral;
    

    //Modificadores de acesso
    //public - O acesso não é restrito
    //private

    //internal
    //protected
    //protected internal
    //private protected


    private void Start()
    {
        CalcularMediaFinal(op);

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
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            CalcularMediaFinal(op);
        }*/
    }

    public void CalcularMediaFinal(int op)
    {
        //float mediaFinal = (mediaBimestreA + mediaBimestreB + mediaBimestreC + mediaBimestreD) / 4;
        float mediaFinal = MediaFinal(op);

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

    private float MediaFinal(int op)
    {
        int indice = 0;
        float media = 0;
        float mFinal = 0;


        switch (op)
        {
            case 1:
                {
                    while (indice < mediaBimestral.Length)
                    {
                        media += mediaBimestral[indice];
                        indice += 1;
                    }
                    break;
                }
            case 2:
                {
                    for (indice = 0; indice < mediaBimestral.Length; indice++)
                    {
                        media += mediaBimestral[indice];
                    }
                    break;
                }
            case 3:
                {
                    foreach (float item in mediaBimestral)
                    {
                        media += item;
                    }
                    break;
                }
            default:
                {
                    foreach (float item in mediaBimestral)
                    {
                        media += item;
                    }
                    break;
                }
        }

        mFinal = media / mediaBimestral.Length;

        return mFinal;
    }
}