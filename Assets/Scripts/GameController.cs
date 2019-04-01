using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("Configuração do Personagem")]
    public float velocidadeMovimento;
    public float limiteMaxX, limiteMinX, limiteMaxY, limiteMinY;

    [Header("Configuração da Ponte")]
    public float velocidadeObjeto;
    public float distanciaDestruir, tamanhoPonte;
    public GameObject pontePrefab;

    [Header("Configuração do Barril")]
    public float posYTop;
    public int orderTop;
    public int orderDown;
    public float posYDown;
    public float tempoSpawn;
    public GameObject barrilPrefab;

    [Header("Configuração Globais")]
    public int score;
    public float posXPlayer;

    private PlayerController _PlayerController;

    private void Start()
    {
        _PlayerController = FindObjectOfType(typeof(PlayerController)) as PlayerController;
        StartCoroutine("SpawnBarril");
    }

    private void LateUpdate()
    {
        posXPlayer = _PlayerController.transform.position.x;
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

        GameObject temp = Instantiate(barrilPrefab);
        temp.transform.position = new Vector3(temp.transform.position.x, posY, 0);
        temp.GetComponent<SpriteRenderer>().sortingOrder = order;
        StartCoroutine("SpawnBarril");
    }

    public void Pontuar(int qtdPontos)
    {
        score += qtdPontos;
    }

    public void MudarCena(string cenaDestino)
    {
        SceneManager.LoadScene(cenaDestino);
    }
}