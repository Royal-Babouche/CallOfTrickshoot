using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private PlayerInTheGameData _playerInTheGameData;
    [SerializeField] private GameParametreData _gameParametreData;
    [SerializeField] private PlayerInputManager _playerInputManager;

    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private GameObject[] _posSpawnsMG, _posSpawnsEquipe01, _posSpawnsEquipe02;

    private void Start()
    {
        AddAllPlayer();
    }

    public void AddAllPlayer()
    {
        for (int i = 0; i < _playerInTheGameData.PlayerProfils.Count; i++)
        {
            if(_gameParametreData.Mode == "MG")
            {
                int random = Random.Range(0, _posSpawnsMG.Length);
                Debug.Log(random);
                GameObject clonePlayer = Instantiate(_playerPrefab, _posSpawnsMG[random].transform.position, _playerPrefab.transform.rotation, this.transform);
                clonePlayer.name = "Clone Player " + _playerInTheGameData.PlayerProfils[i].Pseudo;
                clonePlayer.GetComponent<PlayerSetupChoseTeam>().SetPlayerProfil(_playerInTheGameData.PlayerProfils[i]);
            }
        }
    }
}
