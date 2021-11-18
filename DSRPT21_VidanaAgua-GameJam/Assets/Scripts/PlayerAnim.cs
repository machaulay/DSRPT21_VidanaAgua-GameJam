using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    public Collider AxeCol;

    public void Start()
    {
        AxeCol = GameObject.FindGameObjectWithTag("Axe").GetComponent<Collider>();

    }
    public void Attack(int isActive) {

        if(isActive == 1)
        {
            AxeCol.enabled = true;

        }
        else if (isActive == 2)
        {
            AxeCol.enabled = false;
        }

    }
}
