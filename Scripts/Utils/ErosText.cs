using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErosUtils
{
    public enum TextType
    {
        STATIC, FLOATING
    }
    public class ErosText : MonoBehaviour
    {
        public static TextMesh CreateTextMesh(TextType type, string text, Transform parent, int fontSize, TextAnchor anchor, TextAlignment alignment, Color color, Vector3 localPosition = default(Vector3))
        {
            if (color == null) color = Color.white;

            GameObject gameObject = new GameObject("World_Text", typeof(TextMesh));
            gameObject.layer = 2;
            gameObject.transform.eulerAngles = new Vector3(90, 0, 0);
            gameObject.transform.localScale = new Vector3(0.03f, 0.03f, 0.03f);
            Transform transform = gameObject.transform;
            transform.localPosition = localPosition;
            transform.parent = parent;
            TextMesh textMesh = gameObject.GetComponent<TextMesh>();

            textMesh.color = color;
            textMesh.text = text;
            textMesh.fontSize = fontSize * 3;
            textMesh.alignment = alignment;
            textMesh.anchor = anchor;

            return textMesh;
        }
    }
}
