using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aluno : MonoBehaviour
{

    //modificador   tipo        nome;
    public          string      nomeAluno;
    public          int         idadeAluno;
    private          bool        isAprovado;
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

    public void calcularMediaFinal()
    {

    }
}