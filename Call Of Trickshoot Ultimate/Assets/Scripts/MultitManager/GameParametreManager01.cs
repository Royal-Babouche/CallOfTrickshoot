using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameParametreManager01 : MonoBehaviour
{
    [SerializeField] private List<PlayerInGame> _playerInGames;

    public void AddNewPlayerInGame(PlayerProfil pp, string team, PlayerSetupConfiguration01 psc)
    {
        Debug.Log("AddNewPlayerInGame(PlayerProfil pp, string team) // Ici j'ai le Profil Player In Game a mettre");
        PlayerInGame newPIG = new PlayerInGame(pp, team);
        _playerInGames.Add(newPIG);
        // Ici donner valeur
        psc.SetPlayerInGame(newPIG);
    }

    public PlayerInGame PlayerInGame(int index)
    {
        PlayerInGame playerInGame = _playerInGames[index];
        return playerInGame;
    }

    public PlayerInGame GetPlayerInGame(int i)
    {
        return _playerInGames[i];
    }
}
