using System;
using System.Collections;
using System.Collections.Generic;
using ModularOptions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private intSO coinSO;
    [SceneRef] public string Menu;

    [SerializeField] private GameObject coinCountTMP;
    private TextMeshProUGUI _coinCountTMP;
    
    private int _life;
    private bool _keyCollected;
    private bool _playerAtDoor;

    public int _coinsCollected;
    public AudioSource coinSound;
    //public AudioSource ballKillSound;

    private void Start()
    {
        _life = 1;
        _coinsCollected = 0;
        _keyCollected = false; 
        Player.GetComponent<Animator>().SetBool("isDead", false);
        
        

        _coinCountTMP = coinCountTMP.GetComponent<TextMeshProUGUI>();
        _coinCountTMP.fontSize = 32;
        _coinCountTMP.text = "x " + coinSO.coin;
    }

    private void Update()
    {
        LevelWin();
    }

    private void OnEnable()
    {
        EventManager.OnCoinCollected += UpdateCollectedCoins;
        EventManager.OnDamageTaken += UpdateLife;
        EventManager.OnKeyCollected += UpdateCollectedKey;
        EventManager.PlayerAtDoor += UpdatePlayerAtDoor;
    }
    private void OnDisable()
    {
        EventManager.OnCoinCollected -= UpdateCollectedCoins;
        EventManager.OnDamageTaken -= UpdateLife;
        EventManager.OnKeyCollected -= UpdateCollectedKey;
        EventManager.PlayerAtDoor -= UpdatePlayerAtDoor;
    }
    
    private void UpdateCollectedCoins()
    {
        coinSound.Play();
        coinSO.coin += 1;
        _coinCountTMP.text = "x " + coinSO.coin;
    }

    private void UpdateCollectedKey()
    {
        _keyCollected = true; 
    }

    private void UpdateLife()
    {
        _life -= 1;
        if (_life <= 0)
        {
            Death();
        }
    }

    private void UpdatePlayerAtDoor()
    {
        _playerAtDoor = true;
    }

    private void Death()
    {
        // Trigger death animation
        Player.GetComponent<Animator>().SetBool("isDead", true);
        Player.GetComponent<Animator>().SetTrigger("animTrigger");
        Debug.Log("died");
        coinSO.coin = 0;
        // Start coroutine to wait for 3 seconds before fading to menu
        StartCoroutine(FadeOutTransition());
    }

    private IEnumerator FadeOutTransition()
    {
        yield return new WaitForSeconds(3f);

        
        UnityEngine.SceneManagement.SceneManager.LoadScene(Menu);
    }

    private void LevelWin()
    {
        if(_keyCollected && _playerAtDoor)
        {
            Debug.Log("PlayerWin");
            UnityEngine.SceneManagement.SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        }
    }
}
