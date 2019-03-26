using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrilDeltaTime : MonoBehaviour
{
    public float tempo, velocidade;
    public int fps;

    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = fps;

        StartCoroutine("Pausar");
    }

    void Update()
    {
        float x = 1 * velocidade * Time.deltaTime;
        transform.Translate(new Vector3(x, 0, 0));
    }

    IEnumerator Pausar()
    {
        yield return new WaitForSeconds(tempo);
        Debug.LogError("Stop");
    }
}
