using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErosFloatingText : MonoBehaviour
{
    public TextMesh textMesh;
    public GameObject textObject;

    public float lifeTime = 2f;
    private float alpha = 1f;
    private Color color;
    public string text = "";
    private float destination;

    private void Start()
    {
        textObject = new GameObject("Floating_Text", typeof(TextMesh));
        textMesh = textObject.GetComponent<TextMesh>();
        textMesh.color = Color.cyan;
        textMesh.fontSize = 30;
        textObject.transform.localScale = new Vector3(.1f, .1f, .1f);
        textMesh.alignment = TextAlignment.Center;
        textMesh.anchor = TextAnchor.MiddleCenter;
        textObject.transform.position = transform.position;
        color = textMesh.color;
        destination = textMesh.transform.position.y + 1;
    }

    public void Update()
    {
        textMesh.text = text;
        if (alpha > .01f)
        {
            alpha = Mathf.Lerp(alpha, 0, Time.deltaTime * 5f / lifeTime);
            textObject.transform.position = new Vector3(textObject.transform.position.x, Mathf.Lerp(textMesh.transform.position.y, destination, Time.deltaTime * 15f / lifeTime), textObject.transform.position.z);
            textMesh.color = new Color(color.r, color.g, color.b, alpha);
        }

        else
        {
            Destroy(textObject);
            Destroy(textMesh);
            Destroy(gameObject);
        }
    }
    
    public void SetText(string text)
    {
        textMesh.text = text;
    }
}
