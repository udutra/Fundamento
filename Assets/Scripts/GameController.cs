using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("Configuração do Personagem")]
    public float velocidadeMovimento;
    public float limiteMaxX, limiteMinX, limiteMaxY, limiteMinY;

    [Header("Configuração das Plataformas")]
    public float velocidadePlataforma;
    public float distanciaDestruir, tamanhoPlataforma;
    public GameObject[] plataformaPrefab;

    [Header("Configuração dos Objetos da cena")]
    public float posYTop;
    public int orderTop;
    public int orderDown;
    public float posYDown;
    public float tempoSpawn;
    public GameObject ObjetoPrefab;

    [Header("Configuração do FX Sound")]
    public AudioSource fxSource;
    public AudioClip fxPontos;

    [Header("Configuração Globais")]
    public int score;
    public float posXPlayer;
    public Text txtScore;

    private PlayerController _PlayerController;

    private void Start()
    {
        _PlayerController = FindObjectOfType(typeof(PlayerController)) as PlayerController;
        //StartCoroutine("SpawnBarril");
    }

    private void LateUpdate()
    {
        //posXPlayer = _PlayerController.transform.position.x;
    }

    private IEnumerator SpawnBarril()
    {
        yield return new WaitForSeconds(tempoSpawn);

        float posY = 0;
        int order = 0;
        int rand = Random.Range(0, 100);

        if (rand < 50)
        {
            posY = posYTop;
            order = orderTop;
        }
        else
        {
            posY = posYDown;
            order = orderDown;
        }

        GameObject temp = Instantiate(ObjetoPrefab);
        temp.transform.position = new Vector3(temp.transform.position.x, posY, 0);
        temp.GetComponent<SpriteRenderer>().sortingOrder = order;
        StartCoroutine("SpawnBarril");
    }

    public void Pontuar(int qtdPontos)
    {
        score += qtdPontos;
        txtScore.text = "Score: " + score.ToString();
        fxSource.PlayOneShot(fxPontos);
    }

    public void MudarCena(string cenaDestino)
    {
        SceneManager.LoadScene(cenaDestino);
    }
}