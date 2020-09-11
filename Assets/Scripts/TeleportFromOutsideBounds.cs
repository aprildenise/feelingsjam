using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportFromOutsideBounds : MonoBehaviour
{

    public GameObject teleporter;
    public Transform teleportTo;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == teleporter)
        {
            teleporter.transform.position = teleportTo.position ;
        }
    }
}
