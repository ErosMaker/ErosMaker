using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ErosGUI : MonoBehaviour
{
    private GameObject HUD;

    //Left Menu Content
    Button button;
    void Start()
    {
        HUD = new GameObject("HUD", typeof(Canvas), typeof(GraphicRaycaster), typeof(CanvasScaler));
        HUD.GetComponent<Canvas>().worldCamera = Camera.main;
        HUD.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceCamera;
        HUD.layer = 5;

        GameObject button = ErosUIButton.CreateUIButton("Button", HUD.transform, HUD.GetComponent<Canvas>(), "Testando", 60, Color.white);
    }

    void Update()
    {
        
    }
}
