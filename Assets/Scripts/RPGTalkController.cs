using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPGTALK;

public class RPGTalkController : MonoBehaviour
{

    public RPGTalk rpgtalk { get; private set; }

    public static RPGTalkController instance { get; private set; }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
            return;
        }
        instance = this;
        rpgtalk = GetComponent<RPGTalk>();
    }
}
