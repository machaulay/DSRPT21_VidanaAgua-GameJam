using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC_Script : MonoBehaviour
{
    private GameObject triggeringPlayer;
    private bool triggering;
    private bool dialogo;
    public KeyCode interaction;
    public GameObject npcText;
    public GameObject dialogueBox;
    public TextMeshProUGUI dialogueTxt;
    public GameObject placeholderDialogue;
    public Canvas renderCanvas;

    public static bool esconder = false;

    // Update is called once per frame
    void Update()
    {
        if (triggering) {
            //triggeringPlayer.gameObject.transform.GetChild(1).gameObject.SetActive(true);
            if (Input.GetKeyDown(interaction) && dialogo == false)
            {
                dialogo = true;
                dialogueBox.SetActive(true);
                TextMeshProUGUI tempTextBox = Instantiate(dialogueTxt, placeholderDialogue.transform.position, transform.rotation);
                tempTextBox.transform.SetParent(dialogueBox.transform, false);

            }
        }
        else {
            npcText.SetActive(false);
        }

        if (esconder)
        {
            dialogueBox.SetActive(false);
            esconder = false;
            dialogo = false;

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
            dialogueBox.SetActive(false);

            triggering = false;
            triggeringPlayer = null;
        }
    }
}

