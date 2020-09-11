using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadlyOnExit : DeadlyOnProximity
{

    private bool entered = false;
    private bool exited = false;

    private void Update()
    {
        if (exited) return;

        if (Vector2.Distance(player.transform.position, this.transform.position) <= interactionRadius)
        {
            entered = true;
        }

        if (entered)
        {
            if (Vector2.Distance(player.transform.position, this.transform.position) >= interactionRadius)
            {
                EnableDeadly();
                exited = true;
            }
        }
    }

}
