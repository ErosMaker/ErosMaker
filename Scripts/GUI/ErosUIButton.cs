using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ErosUIButton : MonoBehaviour
{

    public static GameObject CreateUIButton(string name, Transform parent, Canvas canvas, string text, int fontSize, Color bgColor)
    {
        GameObject buttonObject = new(name);
        buttonObject.transform.parent = parent;
        buttonObject.AddComponent<Button>();
        Button button = buttonObject.GetComponent<Button>();

        button.AddComponent<TextMeshPro>();

        TextMeshPro _text = buttonObject.GetComponent<TextMeshPro>();
        _text.fontSize = fontSize;
        _text.text = text;
        _text.color = Color.black;
        buttonObject.transform.localScale = new Vector3(0.03f, 0.03f, 0.03f);

        return buttonObject;
    }
}
