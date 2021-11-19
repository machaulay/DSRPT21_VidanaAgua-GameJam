using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Script : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Game over "Sujo de petróleo"
            GameController.Instance.State = GameController.GameStates.GAMEOVER_01;
            StartCoroutine(GameController.CarregaCena("Gameplay"));
        }
    }

   
}
