using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public Button button;
    public string sceneName;

    // Start is called before the first frame update
    void Start()
    {
       Button btn = button.GetComponent<Button>(); 
       btn.onClick.AddListener(startGame);
    }

    void startGame() {
        SceneManager.LoadScene(sceneName);
    }
}
