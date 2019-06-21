using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    public static Lamp _player;

    public List<Enemy> _visibleEnemy;

    [SerializeField]
    private float _moveSpeed;

    private int _killCount;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;

        if (_player == null)
        {
            _player = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Mouse X");
        transform.Translate(new Vector3(moveHorizontal * _moveSpeed, 0, 0));

        float moveVertical = Input.GetAxis("Mouse Y");
        transform.Translate(new Vector3(0, 0, moveVertical * _moveSpeed));
    }

    public void Add(Enemy enemy)
    {
        _visibleEnemy.Add(enemy);
    }

    public void Remove(Enemy enemy)
    {
        _visibleEnemy.Remove(enemy);
    }
    
    public void RemoveEnemy(Enemy deadEnemy)
    {
        _visibleEnemy.Remove(deadEnemy);
        UIManager._UI.AddCoins(1);
    }
}
