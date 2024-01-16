using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class PlayerConfiguration
{
    [SerializeField] private PlayerInput _input;
    [SerializeField] private int _playerIndex;
    [SerializeField] private PlayerProfil _playerProfil;

    public PlayerConfiguration(PlayerInput pi)
    {
        _playerIndex = pi.playerIndex;
        _input = pi;
    }


    public PlayerInput Input { get => _input; set => _input = value; }
    public int PlayerIndex { get => _playerIndex; set => _playerIndex = value; }
    public PlayerProfil PlayerProfil { get => _playerProfil; set => _playerProfil = value; }
}
