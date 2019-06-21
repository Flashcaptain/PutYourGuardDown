using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager _UI;
    public int _coins = 20;


    [SerializeField]
    private Text _coinText;

    [SerializeField]
    private Text _healthText;

    [SerializeField]
    private Text _costText;

    [SerializeField]
    private Text _popupText;

    [SerializeField]
    private GameObject _gameover;

    [SerializeField]
    private float _popupTime;

    [SerializeField]
    private float _gameoverTime;

    [SerializeField]
    private List<AudioClip> _songs;

    [SerializeField]
    private AudioSource _audioSource;

    private int _towerCount;
    private int _currentSong = 0;

    public void Start()
    {
        StartCoroutine(Music());
        _coinText.text = "coins: " + _coins;
        _popupText.text = "";
        _costText.text = "Sniper cost: 20\nLMG cost: 15";

        if (_UI == null)
        {
            _UI = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void AddCoins(int coins)
    {
        _coins += coins;
        _coinText.text = "coins: " + _coins;
    }

    public void RemoveCoins(int coins)
    {
        _coins -= coins;
        _coinText.text = "coins: " + _coins;
    }

    public void ChangeCost(int costLMG, int costSniper)
    {
        _towerCount++;
        if (_towerCount == 8)
        {
            _costText.text = "max reached";
            return;
        }
        _costText.text = "Sniper cost: " + costSniper + "\nLMG cost: " + costLMG;
    }

    public void SetHealth(int health)
    {
        _healthText.text = "health: " + health;
    }

    public void PopupText(string text)
    {
        _popupText.text = text;
        StartCoroutine(TextTime());
    }


    private IEnumerator TextTime()
    {
        yield return new WaitForSeconds(_popupTime);
        _popupText.text = "";
    }

    public void Gameover()
    {
        StartCoroutine(GameoverTime());
    }

    private IEnumerator GameoverTime()
    {
        _gameover.SetActive(true);
        Time.timeScale = 0.01f;
        yield return new WaitForSeconds(_gameoverTime / (1 / 0.01f));
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(0);
    }

    private IEnumerator Music()
    {
        _audioSource.clip =_songs[_currentSong];
        _audioSource.Play();
        yield return new WaitForSeconds(_songs[_currentSong].length);
        if (_towerCount >= (_currentSong + 1)*2)
        {
            _currentSong++;
        }
        StartCoroutine(Music());
    }
}
