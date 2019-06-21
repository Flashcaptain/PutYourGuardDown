using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{

    void OnTriggerEnter(Collider colEnter)
    {
        Enemy enemy = colEnter.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.FadeIn();

            if (!enemy._isDead)
            {
                Lamp._player.Add(enemy);
                return;
            }
        }

        Freindly freindly = colEnter.GetComponent<Freindly>();
        if (freindly != null)
        {
            freindly.FadeIn();
        }

    }

    void OnTriggerExit(Collider colExit)
    {
        Enemy enemy = colExit.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.Fadeout();
            Lamp._player.Remove(enemy);
            return;
        }
        Freindly freindly = colExit.GetComponent<Freindly>();
        if (freindly != null)
        {
            freindly.Fadeout();
        }
    }
}
