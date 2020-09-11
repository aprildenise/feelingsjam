using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadly : MonoBehaviour
{

    public bool pseudoDeadly = false;
    private ParticleSystem particles;
    private GameManager game;

    private void Start()
    {
        particles = GetComponent<ParticleSystem>();
        particles.Play();
        game = GameManager.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!enabled || pseudoDeadly) return;

        if (collision.CompareTag("Player"))
        {
            game.GoToScene(4);
        }
    }

}
