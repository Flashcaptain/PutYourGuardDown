using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField]
    private float _fireRate;

    [SerializeField]
    private int _damage;

    [SerializeField]
    private Transform _barrleEnd;

    [SerializeField]
    private LineRenderer _trail;

    [SerializeField]
    private GameObject _flash;

    [SerializeField]
    private float _flashDuration;

    [SerializeField]
    private AudioSource _gunsound;

    private bool _onCooldown;

    void Update()
    {

        if (Lamp._player._visibleEnemy.Count != 0)
        {
            Fire();
        }
    }

    void Fire()
    {
        if (!_onCooldown)
        {
            StartCoroutine(Cooldown());
            Enemy closestEnemy = null;
            float smallestDistance = 0;
            List<Enemy> enemy = Lamp._player._visibleEnemy;

            for (int i = 0; i < enemy.Count; i++)
            {
                var currentDistance = Vector3.Distance(enemy[i].transform.position, transform.position);
                if (closestEnemy == null || smallestDistance > currentDistance)
                {
                    closestEnemy = enemy[i];
                    smallestDistance = currentDistance;
                }
            }
            StartCoroutine(FlashDuration(closestEnemy));
            _gunsound.Play();

            closestEnemy.TakeDamage(_damage);
            transform.LookAt(closestEnemy.transform);
        }

    }

    private IEnumerator Cooldown()
    {
        _onCooldown = true;
        yield return new WaitForSeconds((1 / _fireRate) + Random.Range(0, (1 / _fireRate)/10));
        _onCooldown = false;
    }

    private IEnumerator FlashDuration(Enemy closestEnemy)
    {
        _flash.SetActive(true);
        _trail.SetPosition(0, _barrleEnd.position);
        _trail.SetPosition(1, closestEnemy.transform.position);
        yield return new WaitForSeconds(_flashDuration);
        _flash.SetActive(false);
        _trail.SetPosition(0, new Vector3(0, 0, 0));
        _trail.SetPosition(1, new Vector3(0, 0, 0));
    }
}
