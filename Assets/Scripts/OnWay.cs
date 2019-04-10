using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnWay : MonoBehaviour
{
    private GameController _GameController;
    public Transform superficie;
    public BoxCollider2D colisor;
    

    void Start()
    {
        _GameController = FindObjectOfType(typeof(GameController)) as GameController;
    }

    // Update is called once per frame
    void Update()
    {
        if(superficie.position.y < _GameController.posY)
        {
            colisor.enabled = true;
        }
        else
        {
            colisor.enabled = false;
        }
    }
}
