using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerInGame
{
    [SerializeField] private PlayerProfil _playerProfil;
    [SerializeField] private string _team;
    [SerializeField] private bool _hitMarker;
    [SerializeField] private int _scoreTotal;

    public PlayerInGame(PlayerProfil pp)
    {
        _playerProfil = pp;
        _team = "none";
    }

    public PlayerInGame(PlayerProfil pp, string team)
    {
        _playerProfil = pp;
        _team = team;
    }

    public void SetHit(bool value)
    {
        _hitMarker = value;
        Debug.Log("SetHit : " + _hitMarker);
    }

    public bool HitMarker { get => _hitMarker; set => _hitMarker = value; }
    public PlayerProfil PlayerProfil { get => _playerProfil; set => _playerProfil = value; }
    public int ScoreTotal { get => _scoreTotal; set => _scoreTotal = value; }
}
