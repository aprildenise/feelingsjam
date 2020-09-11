using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnimateLeeInBar : MonoBehaviour
{

    public Transform goTo;
    public TextMeshProUGUI text;

    private bool reachedGoal = false;

    private void Update()
    {

        if (text.text.Equals("Zel, is that you?"))
        {
            transform.Translate(Vector2.left * Time.deltaTime);
        }

        if (transform.position.x <= goTo.position.x)
        {
            reachedGoal = true;
            enabled = false;
        }
    }

}
