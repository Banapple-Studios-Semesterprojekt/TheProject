using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private SpriteRenderer cat;

    public Color originalColor;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cat"))
        {
            cat=other.GetComponent<SpriteRenderer>();
            cat.color = new Color(1, 0, 0, 1);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Cat"))
        {
            cat.color = originalColor;
        }
    }
}