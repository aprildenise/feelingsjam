using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableUIOnTrigger : MonoBehaviour
{

    private RPGTalkController talk;
    public GameObject ui;

    private void Start()
    {
        talk = RPGTalkController.instance;
    }

    private void Update()
    {
        if (talk.rpgtalk.isPlaying) ui.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (talk.rpgtalk.isPlaying) return;
        if (collision.CompareTag("Player"))
        {
            ui.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (talk.rpgtalk.isPlaying) return;
        if (collision.CompareTag("Player"))
        {
            ui.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (talk.rpgtalk.isPlaying) return;
        if (collision.CompareTag("Player"))
        {
            ui.SetActive(false);
        }
    }
}
