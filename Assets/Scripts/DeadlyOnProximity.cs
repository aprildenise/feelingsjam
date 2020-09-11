using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadlyOnProximity : MonoBehaviour
{

    public float interactionRadius;

    private PlayerController player;
    private Deadly deadly;

    private void Start()
    {
        player = PlayerController.instance;
        deadly = GetComponent<Deadly>();
        deadly.enabled = false;
    }

    private void Update()
    {
        if (Vector2.Distance(player.transform.position, this.transform.position) <= interactionRadius)
        {
            deadly.enabled = true;
        }
    }



}
