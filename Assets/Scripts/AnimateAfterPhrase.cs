using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnimateAfterPhrase : MonoBehaviour
{
    public Transform goTo;
    public string phrase;
    public TextMeshProUGUI text;
    public float translateSpeed;

    private bool reachedGoal = false;
    private bool passedPhrase = false;

    private void Update()
    {
        if (reachedGoal) return;

        if (text.text.Contains(phrase))
        {
            passedPhrase = true;
        }
        
        if (passedPhrase)
        {
            transform.Translate(Vector2.left * Time.deltaTime * translateSpeed);
        }

        if (Vector2.Distance(transform.position, goTo.position) < .5f)
        {
            reachedGoal = true;
            enabled = false;
        }
    }
}
