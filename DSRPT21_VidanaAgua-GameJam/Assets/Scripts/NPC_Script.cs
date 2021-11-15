using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Script : MonoBehaviour
{
    private GameObject triggeringPlayer;
    private bool triggering;

    public GameObject npcText;
    public GameObject dialogueBox;



    // Update is called once per frame
    void Update()
    {
        if (triggering) {
            //triggeringPlayer.gameObject.transform.GetChild(1).gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Return))
            {
                dialogueBox.SetActive(true);
            }
        }
        else {
            npcText.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            triggering = true;
            triggeringPlayer = other.gameObject;
            npcText.SetActive(true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            triggering = false;
            triggeringPlayer = null;
        }
    }
}

