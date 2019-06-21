using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freindly : MonoBehaviour
{
    public Transform _target;

    [SerializeField]
    private float _speed;

    [SerializeField]
    private SpriteRenderer _sprite;

    [SerializeField]
    private Color _fadeColor;

    void Start()
    {
        Fadeout();
    }

    public void FadeIn()
    {
        _sprite.color = new Color(35, 35, 35, 35);
    }

    public void Fadeout()
    {
        _sprite.color = _fadeColor;
    }

    void Update()
    {
        transform.LookAt(_target);
        transform.Translate(transform.forward * -_speed * Time.deltaTime);
    }
}
