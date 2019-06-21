using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _towers;

    [SerializeField]
    private List<Transform> _spawnpoints;

    [SerializeField]
    private List<GameObject> _nummerText;

    [SerializeField]
    private List<GameObject> _towerIcons;

    private List<int> _occupiedSpots;

    private bool _isSelecting = false;

    private int _spawnPosition;
    private int _costLMG = 15;
    private int _costSniper = 20;

    void Start()
    {
        _occupiedSpots = new List<int>();
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {

            if (_isSelecting)
            {

                switch (Input.inputString)
                {
                    case "q":
                        if (UIManager._UI._coins >= _costLMG)
                        {

                            UIManager._UI.RemoveCoins(_costLMG);
                            _costLMG *= 2;
                            _costSniper *= 2;
                            UIManager._UI.ChangeCost(_costLMG, _costSniper);
                            SpawnTower(1);
                        }
                        else
                        {
                            UIManager._UI.PopupText("not enough coins");
                        }
                        break;
                    case "w":
                        if (UIManager._UI._coins >= _costSniper)
                        {
                            UIManager._UI.RemoveCoins(_costSniper);
                            _costLMG *= 2;
                            _costSniper *= 2;
                            UIManager._UI.ChangeCost(_costLMG, _costSniper);
                            SpawnTower(2);
                        }
                        else
                        {
                            UIManager._UI.PopupText("not enough coins");
                        }
                        break;
                    default:
                        _nummerText[_spawnPosition - 1].SetActive(true);
                        StopSelecting();
                        break;
                }
                return;
            }
            switch (Input.inputString)
            {
                case "1":
                    SelectSpot(1);
                    break;
                case "2":
                    SelectSpot(2);
                    break;
                case "3":
                    SelectSpot(3);
                    break;
                case "4":
                    SelectSpot(4);
                    break;
                case "5":
                    SelectSpot(5);
                    break;
                case "6":
                    SelectSpot(6);
                    break;
                case "7":
                    SelectSpot(7);
                    break;
                case "8":
                    SelectSpot(8);
                    break;
                default:
                    break;



            }
        }
    }
    private void SelectSpot(int spawnPosition)
    {
        if (spawnPosition > _spawnpoints.Count)
        {
            return;
        }
        if (_occupiedSpots != null)
        {
            for (int i = 0; i < _occupiedSpots.Count; i++)
            {
                if (_occupiedSpots[i] == spawnPosition)
                {
                    return;
                }
            }
        }
        _spawnPosition = spawnPosition;
        _nummerText[spawnPosition -1].SetActive(false);
        _towerIcons[spawnPosition - 1].SetActive(true);
        _isSelecting = true;
    }

    private void SpawnTower(int tower)
    {
        _towerIcons[_spawnPosition - 1].SetActive(false);
        GameObject Tower = Instantiate(_towers[tower - 1], _spawnpoints[_spawnPosition - 1]);
        _occupiedSpots.Add(_spawnPosition);
        StopSelecting();
    }

        private void StopSelecting()
    {
        _towerIcons[_spawnPosition - 1].SetActive(false);
        _isSelecting = false;
    }
}
