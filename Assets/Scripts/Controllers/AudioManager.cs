using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioClip[] audios;
    private AudioSource audio;

    private int currentAudio = 0;

    public static AudioManager instance { get; private set; }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        instance = this;
        audio = GetComponent<AudioSource>();
    }

    public void SetAudio(int index)
    {
        if (index == currentAudio) return;
        audio.Stop();
        audio.clip = audios[index];
        audio.Play();
        currentAudio = index;
    }



}
