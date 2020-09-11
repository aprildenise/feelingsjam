using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractForNewScene : MonoBehaviour
{

    public int sceneIndex;
    public bool waitForInput;

    private PlayerController player;

    private void Start()
    {
        player = PlayerController.instance;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!waitForInput)
            {
                SceneManager.LoadScene(sceneIndex);
            }
            else
            {
                player.exclamation.SetActive(true);
            }

            if (waitForInput && Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(sceneIndex);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (waitForInput && Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(sceneIndex);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            player.exclamation.SetActive(false);
        }
    }

}
