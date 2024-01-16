using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField] private PlayerProfilManagerData _playerProfilManagerData;
    [SerializeField] private PlayerInTheGameData _playerInTheGameData;
    [SerializeField] private GameParametreData _gameParametreData;

    private void Awake()
    {
        _playerProfilManagerData.Instance();
        _playerInTheGameData.Instance();
        // _gameParametreData.Instance();
    }

    public PlayerProfilManagerData PlayerProfilManagerData { get => _playerProfilManagerData; set => _playerProfilManagerData = value; }
    public PlayerInTheGameData PlayerInTheGameData { get => _playerInTheGameData; set => _playerInTheGameData = value; }
    public GameParametreData GameParametreData { get => _gameParametreData; set => _gameParametreData = value; }
}
