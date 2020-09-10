﻿using UnityEngine;
using System.Collections;

public class PingPong : MonoBehaviour
{

    public float delta = 1.5f;  // Amount to move left and right from the start point
    public float speed = 2.0f;
    private Vector3 startPos;
    private Animator anim;
    private SpriteRenderer sprite;
    private RPGTalkController talk;

    void Start()
    {
        startPos = transform.position;
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        talk = RPGTalkController.instance;
    }

    void Update()
    {
        if (talk.rpgtalk.isPlaying) return;

        // Calculate ping pong movement.
        Vector2 movement = startPos;
        float change = Mathf.Sin(Time.time * speed);

        // Apply animations and sprite flips.
        if (change >= .99f) sprite.flipX = true;
        if (change <= -.99f) sprite.flipX = false;

        // Apply ping pong movement.
        movement.x += change * delta;
        transform.position = movement;
    }
}
