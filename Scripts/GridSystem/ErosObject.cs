using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErosObject : MonoBehaviour
{
    private void Start()
    {
        transform.localScale = new Vector3(1.3f, 2f, 1.3f);
    }
    void Update()
    {
        if(transform.localScale.y > 1.0f)
        {
            transform.localScale = new Vector3(Mathf.Lerp(transform.localScale.x, 1.0f, Time.deltaTime * 10f), 
                                               Mathf.Lerp(transform.localScale.y, 1.0f, Time.deltaTime * 10f), 
                                               Mathf.Lerp(transform.localScale.z, 1.0f, Time.deltaTime * 10f));
        }
    }
}
