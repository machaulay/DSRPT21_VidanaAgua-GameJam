using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControle : MonoBehaviour
{
    public GameObject TargetPreFab;
    public Transform[] Spot;
    public static bool Spawn;

    public Transform[] ways;

   

    void Start()
    {
        Spawn = false;
    }

    void Update()
    {

        if (Spawn)
        {
            Instantiate(TargetPreFab, Spot[Random.Range(0, Spot.Length)].position, TargetPreFab.transform.rotation);
            Spawn = false;
        }
    }
}
