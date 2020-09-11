using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadlyOnProximity : MonoBehaviour
{

    public float interactionRadius;

    protected PlayerController player;
    protected Deadly deadly;

    protected void Start()
    {
        player = PlayerController.instance;
        deadly = GetComponent<Deadly>();
        deadly.enabled = false;
    }

    private void Update()
    {
        if (Vector2.Distance(player.transform.position, this.transform.position) <= interactionRadius)
        {
            EnableDeadly();
        }
    }

    protected void EnableDeadly()
    {
        deadly.enabled = true;
    }

    protected void OnDrawGizmos()
    { 
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }


}
