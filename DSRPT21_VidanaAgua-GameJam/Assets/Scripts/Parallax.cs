using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    private float startPos;

    private Transform cam;

    public float parallaxEffect;

    void Start()
    {
        startPos = transform.position.x;
        cam = Camera.main.transform;
    }

    void Update()
    {
        float Distance = cam.transform.position.x * parallaxEffect;

        transform.position = new Vector3(startPos + Distance, transform.position.y, transform.position.z);
    }
}