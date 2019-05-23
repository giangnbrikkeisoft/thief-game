using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakSlug : MonoBehaviour
{
    [SerializeField]
    private EdgeCollider2D weak1, weak2;

    public bool hitWeak = false;

    public void ActiveWeak1()
    {
        weak1.enabled = true;
        weak2.enabled = false;
    }

    public void ActiveWeak2()
    {
        weak1.enabled = false;
        weak2.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            hitWeak = true;
        }
    }
}
