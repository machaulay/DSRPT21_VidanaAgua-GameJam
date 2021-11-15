using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Story : MonoBehaviour
{
    public GameObject[] frames;
    public float speed;
    private int currentFrame;


    void Start()
    {
        currentFrame = 0;
        StartCoroutine(Next());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
            if (currentFrame > 0) {
                currentFrame--;
            }
            
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
            AddFrame();
            
        }

        Vector3 p = new Vector3(frames[currentFrame].transform.position.x, transform.position.y,
            transform.position.z);
        transform.position = Vector3.Lerp(transform.position, 
            p, speed * Time.deltaTime);
    }

    IEnumerator Next() {
        yield return new WaitForSeconds(5f);
        AddFrame();
        StartCoroutine(Next());
    }

    void AddFrame() {
        if (currentFrame < frames.Length - 1) {
            currentFrame++;
        }else{ 
            SceneManager.LoadScene("Gameplay");
        }
    }
}
