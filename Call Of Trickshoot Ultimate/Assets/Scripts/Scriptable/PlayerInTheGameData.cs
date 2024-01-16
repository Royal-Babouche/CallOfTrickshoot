using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerInTheGameData : ScriptableObject
{
    [SerializeField] private int _sizeMax;
    [SerializeField] private List<PlayerProfil> _playerProfils;

    [SerializeField] private bool _inMenu, _inPersonnalisation, _inGame;

    public void Instance()
    {
        _playerProfils = new List<PlayerProfil>();
        _inMenu = false;
        _inPersonnalisation = false;
        _inGame = false;
    }

    public void AddPlayer(PlayerProfil ppToAdd)
    {
        _playerProfils.Add(ppToAdd);
    }

    public void SetReadyIsNullForAll()
    {
        for (int i = 0; i < _playerProfils.Count; i++)
        {
            _playerProfils[i].IsReady = false;
        }
    }

    public bool IfAllIsReady()
    {
        bool verif = false;
        int cpt = 0;
        for (int i = 0; i < _playerProfils.Count; i++)
        {
            if (_playerProfils[i].IsReady)
            {
                cpt++;
            }
        }
        if(cpt == _playerProfils.Count)
        {
            verif = true;
        }
        return verif;
    }

    public bool InMenu { get => _inMenu; set => _inMenu = value; }
    public bool InPersonnalisation { get => _inPersonnalisation; set => _inPersonnalisation = value; }
    public bool InGame { get => _inGame; set => _inGame = value; }
    public List<PlayerProfil> PlayerProfils { get => _playerProfils; set => _playerProfils = value; }
}
