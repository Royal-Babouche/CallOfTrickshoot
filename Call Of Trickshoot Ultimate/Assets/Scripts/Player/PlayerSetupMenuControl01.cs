using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSetupMenuControl01 : MonoBehaviour
{
    [SerializeField] private int _playerIndex;
    [SerializeField] private PlayerConfiguration _playerConfig;
    [SerializeField] private TextMeshProUGUI _titleTextConnexion, _readyButtonTexte;

    private float ignoreInputTime = 1.5f;
    private bool inputEnable;

    private void Update()
    {
        if (Time.time > ignoreInputTime)
        {
            inputEnable = true;
        }
    }

    public void SetPlayerIndex(int pi)
    {
        _playerIndex = pi;
        _titleTextConnexion.SetText("Player " + (pi + 1).ToString());
        ignoreInputTime += Time.time;
    }

    public void SetPlayerIndex(PlayerConfiguration pc)
    {
        _playerConfig = pc;
        _playerIndex = _playerConfig.PlayerIndex;
        _titleTextConnexion.SetText("Player " + (_playerIndex + 1).ToString());
        ignoreInputTime += Time.time;
    }

    public void ReadyPlayer()
    {
        if (!inputEnable) { return; }

        if (PlayerInTheGame01.Instance.ReadyPlayer(_playerIndex))
        {
            _readyButtonTexte.text = "Is Ready";
        }
        else
        {
            _readyButtonTexte.text = "Ready";
        }
    }
}
