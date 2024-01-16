using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameParametreData : ScriptableObject
{
    // Game Parametre
    [SerializeField] private string _mode, _score, _time, _manche, _map;
    [SerializeField] private bool _esclave, _traversInfini;

    // Les Joueurs en jeu
    [SerializeField] private int _nbJoueurTotal;
    [SerializeField] private List<PlayerInGame> _playerInGames;

    public void Instance()
    {
        _mode = "";
        _score = "";
        _time = "";
        _manche = "";
        _map = "";
        _esclave = false;
        _traversInfini = false;

        _nbJoueurTotal = 0;
        _playerInGames = new List<PlayerInGame>();
    }

    public void ModifieAllValue(string mode, string score, string time, string manche, string map, bool esclave, bool traversInfini)
    {
        _mode = mode;
        _score = score;
        _time = time;
        _manche = manche;
        _map = map;
        _esclave = esclave;
        _traversInfini = traversInfini;
    }

    public bool IfTeam()
    {
        bool verif = false;
        if(_mode != "MG")
        {
            verif = true;
        }
        return verif;
    }

    public void InstanceListePLayerInGame(int nbJoueurTotal)
    {
        _nbJoueurTotal = nbJoueurTotal;
    }

    public void AddNewPlayerInGame(PlayerProfil pp, string team, PlayerSetupConfiguration01 psc)
    {
        Debug.Log("AddNewPlayerInGame(PlayerProfil pp, string team) // Ici j'ai le Profil Player In Game a mettre");
        PlayerInGame newPIG = new PlayerInGame(pp, team);
        _playerInGames.Add(newPIG);
        // Ici donner valeur
        psc.SetPlayerInGame(newPIG);

        if(_esclave)
        {
            PlayerProfil esclave = new PlayerProfil(pp);
            PlayerInGame newPIGEsclave = new PlayerInGame(esclave, team);
            _playerInGames.Add(newPIGEsclave);
        }
    }

    public void AjouteScoreJoueur(int indexJoueur)
    {

    }

    public PlayerInGame GetPlayerInGame(int i)
    {
        return _playerInGames[i];
    }

    public string Mode { get => _mode; set => _mode = value; }
    public string Score { get => _score; set => _score = value; }
    public string Time { get => _time; set => _time = value; }
    public string Map { get => _map; set => _map = value; }
    public bool Esclave { get => _esclave; set => _esclave = value; }
    public string Manche { get => _manche; set => _manche = value; }
    public bool TraversInfini { get => _traversInfini; set => _traversInfini = value; }
}
