using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicCam : MonoBehaviour
{
    public GameObject gridSystem;
    private Vector3 camPosition;
    private float rotSpeed = 2.0f;
    private float yAxisAngle = 0.0f;

    void Start()
    {
        camPosition = gridSystem.GetComponent<GridSystem>().GetCameraTransform();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.LeftAlt) && Input.GetMouseButton(1))
        {
            Rotate();
        }

        if(transform.position.Equals(camPosition))
        {
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, camPosition.x, Time.deltaTime * 10f),
                                             Mathf.Lerp(transform.position.y, camPosition.y, Time.deltaTime * 10f),
                                             Mathf.Lerp(transform.position.z, camPosition.z, Time.deltaTime * 10f));
        }
    }

    private void Rotate()
    {
        transform.position = new Vector3(Mathf.Cos(yAxisAngle), transform.eulerAngles.y, Mathf.Sin(yAxisAngle));
    }

    private void Move()
    {

    }
}
