using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    private int _health = 10;

    void Start()
    {
        UIManager._UI.SetHealth(_health);
    }

    void OnTriggerEnter(Collider colEnter)
    {
        Enemy enemy = colEnter.GetComponent<Enemy>();
        if (enemy != null)
        {
            _health--;
            UIManager._UI.SetHealth(_health);
            OnFinnish(colEnter);
            return;
        }

        Freindly freindly = colEnter.GetComponent<Freindly>();
        if (freindly != null)
        {
            _health++;
            UIManager._UI.SetHealth(_health);
            OnFinnish(colEnter);
            return;
        }
    }

    void OnFinnish(Collider colEnter)
    {
        Destroy(colEnter.gameObject);
        if (_health <= 0)
        {
            UIManager._UI.Gameover();
        }
    }
}
