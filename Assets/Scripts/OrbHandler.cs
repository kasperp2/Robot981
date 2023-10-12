using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbHandler : MonoBehaviour
{
    private CircleCollider2D _collider;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _collider = GetComponentInChildren<CircleCollider2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Disable();
        }
    }

    public void Enable()
    {
        _collider.enabled = true;
        _spriteRenderer.enabled = true;
    }

    public void Disable()
    {
        _collider.enabled = false;
        _spriteRenderer.enabled = false;
    }
}
