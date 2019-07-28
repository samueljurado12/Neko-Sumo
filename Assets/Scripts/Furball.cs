using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furball : MonoBehaviour
{
    public new Rigidbody2D rigidbody;
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    int counter = 0;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //counter++;
        //if (counter == 2)
        //{
            spriteRenderer.DOFade(0, 0.25f);
            transform.DOScale(0.5f, 0.5f).OnComplete(() => Destroy(gameObject));
        //}
        
    }
}
