using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private AudioManager audio;

    public static GameManager instance { get; private set; }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
            return;
        }
        instance = this;
    }

    private void Start()
    {
        audio = AudioManager.instance;
    }

    public void GoToScene(int index)
    {
        SceneManager.LoadScene(index);
        if (index <= 3)
        {
            audio.SetAudio(0);
        }
        else
        {
            audio.SetAudio(1);
        }
    }
}
