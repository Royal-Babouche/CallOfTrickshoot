using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class PlayerProfil
{
    [SerializeField] private bool _isConnected, _isReady;
    [SerializeField] private string _pseudo;
    [SerializeField] private int _level, _xpCurrent, _xpMax;
    [SerializeField] private PlayerClasseManager _playerClasseManager;

    public PlayerProfil()
    {

    }

    public PlayerProfil(string pseudo)
    {
        _isConnected = false;
        _isReady = false;
        _playerClasseManager = new PlayerClasseManager();
        _pseudo = pseudo;
        _level = 0;
        LevelUp();
    }

    public PlayerProfil(PlayerProfil playerProfil)
    {
        _isConnected = true;
        _isReady = true;
        _playerClasseManager = playerProfil.PlayerClasseManager;
        _pseudo = "Esclave_"+playerProfil.Pseudo;
        _level = playerProfil.Level;
    }

    public void Instance()
    {
        _isConnected = false;
        _isReady = false;
    }

    public void LevelUp()
    {
        _level++;
        _xpCurrent = 0;
        _xpMax = _level * (1000 * (_level / 10 + 1));
    }

    public void SetIsConnected(bool value)
    {
        _isConnected = value;
    }

    public string Pseudo { get => _pseudo; set => _pseudo = value; }
    public int Level { get => _level; set => _level = value; }
    public int XpCurrent { get => _xpCurrent; set => _xpCurrent = value; }
    public int XpMax { get => _xpMax; set => _xpMax = value; }
    public PlayerClasseManager PlayerClasseManager { get => _playerClasseManager; set => _playerClasseManager = value; }
    public bool IsConnected { get => _isConnected; set => _isConnected = value; }
    public bool IsReady { get => _isReady; set => _isReady = value; }
}
