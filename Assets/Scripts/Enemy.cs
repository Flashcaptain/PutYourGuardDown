using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform _target;

    [SerializeField]
    private float _speed;

    [SerializeField]
    private int _heath;

    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private string _triggerName;

    [SerializeField]
    private SpriteRenderer _sprite;

    [SerializeField]
    private Color _fadeColor;

    public bool _isDead;

    void Start()
    {
        Fadeout();
    }

    void Update()
    {
        if (_isDead)
        {
            return;
        }
        transform.LookAt(_target);
        transform.Translate(transform.forward * -_speed *Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        _heath -= damage;
        if (_heath <= 0)
        {
            Death();
        }
    }

    public void FadeIn()
    {
        _sprite.color = new Color(35,35,35,35);
    }

    public void Fadeout()
    {
        _sprite.color = _fadeColor;
    }

    void Death()
    {
        Lamp._player.RemoveEnemy(this);
        _animator.SetTrigger(_triggerName);
        _isDead = true;
    }
}
