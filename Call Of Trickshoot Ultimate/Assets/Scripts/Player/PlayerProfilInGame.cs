using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProfilInGame : MonoBehaviour
{
    [SerializeField] private PlayerInGame _playerInGame;
    [SerializeField] private PlayerUI playerUI;

    public void SetPlayerInGame(PlayerInGame playerProfil)
    {
        _playerInGame = playerProfil;
    }

    public PlayerInGame PlayerInGame { get => _playerInGame; set => _playerInGame = value; }
}
