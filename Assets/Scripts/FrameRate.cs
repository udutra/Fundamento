using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRate : MonoBehaviour
{
    public int numFrame, vsync;

    private void Start()
    {
        QualitySettings.vSyncCount = vsync;
        Application.targetFrameRate = numFrame;
    }
}
