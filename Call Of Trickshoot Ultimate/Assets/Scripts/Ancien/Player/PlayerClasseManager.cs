using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerClasseManager
{
    [SerializeField] private int _sizeMax;
    [SerializeField] private List<PlayerClasse> _playerClasses;

    public PlayerClasseManager()
    {
        _sizeMax = 5;
        _playerClasses = new List<PlayerClasse>();
    }
}
