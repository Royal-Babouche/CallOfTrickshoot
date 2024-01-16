using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class LevelInitialize01 : MonoBehaviour
{
    [SerializeField] private GameParametreData _gameParametreData;
    [SerializeField] private GameObject _panelChoseTeamPrefabs;
    [SerializeField] private Transform[] _playerSpawns;
    [SerializeField] private PlayerInputManager _playerInputManager;
    [SerializeField] private Transform _newRootMenu, _newParentPlayer, _newParentEsclave, _bulletParent;

    private void Start()
    {
        SpwanPanelChoseForAllPlayer();
    }

    public void SpwanPanelChoseForAllPlayer()
    {
        var playerConfigs = PlayerInTheGame01.Instance.GetPlayerConfigs().ToArray();
        for (int i = 0; i < playerConfigs.Length; i++)
        {
            playerConfigs[i].Input.GetComponent<PlayerSetupConfiguration01>().SetRootMenu(_newRootMenu);
            GameObject newPanelCHoseTeam = Instantiate(_panelChoseTeamPrefabs, _newRootMenu);
            newPanelCHoseTeam.GetComponent<PanelChoseTeam01>().SetPlayer(this, playerConfigs[i], _gameParametreData.IfTeam());
        }

        if(_gameParametreData.Esclave)
        {
            _gameParametreData.InstanceListePLayerInGame(playerConfigs.Length * 2);
        }
        else
        {
            _gameParametreData.InstanceListePLayerInGame(playerConfigs.Length);
        }
    }

    public void SpwanPlayer(int index, string team)
    {
        Debug.Log("SpwanPlayer(int " + index + ", string team : + " + team);
        var playerConfigs = PlayerInTheGame01.Instance.GetPlayerConfigs().ToArray();

        Debug.Log("playerConfigs[index].Input.name = " + playerConfigs[index].Input.name);
        Debug.Log("ICI MODIFICATION PLAYERLISTE");
        _gameParametreData.AddNewPlayerInGame(playerConfigs[index].PlayerProfil, team, playerConfigs[index].Input.GetComponent<PlayerSetupConfiguration01>());

        if (_gameParametreData.IfTeam())
        {

        }
        else
        {
            //playerConfigs[index].Input.GetComponentInChildren<PlayerUI>().AjouterUnPlayerTestNoTeam(playerConfigs[index].PlayerProfil.Pseudo);
            playerConfigs[index].Input.GetComponentInChildren<PlayerUI>().AjouterUnPlayerTestNoTeam(_gameParametreData.GetPlayerInGame(index));
        }

        playerConfigs[index].Input.transform.GetChild(0).transform.position = _playerSpawns[index].position;
        playerConfigs[index].Input.GetComponent<PlayerSetupConfiguration01>().InitializePlayerInGame(_bulletParent);
        playerConfigs[index].Input.GetComponentInChildren<PlayerHandlerInput01>().InitializePlayer(playerConfigs[index]);

        if (_gameParametreData.Esclave)
        {
            if (_gameParametreData.IfTeam())
            {

            }
            else
            {

                //playerConfigs[index].Input.GetComponentInChildren<PlayerUI>().AjouterUnPlayerTestNoTeam(_gameParametreData.GetPlayerInGame(index+1).PlayerProfil.Pseudo);
                playerConfigs[index].Input.GetComponentInChildren<PlayerUI>().AjouterUnPlayerTestNoTeam(_gameParametreData.GetPlayerInGame(index + 1));
            }

            playerConfigs[index].Input.transform.GetChild(1).transform.position = _playerSpawns[index + 1].position;
            playerConfigs[index].Input.GetComponentInChildren<PlayerEsclave>().SetActiveGo(true);
            playerConfigs[index].Input.transform.GetChild(1).transform.SetParent(_newParentEsclave);
            Debug.Log("Ici ajouter esclave dans les player in game");
        }

        playerConfigs[index].Input.transform.GetChild(0).transform.SetParent(_newParentPlayer);
        //_gameParametreManager.AddNewPlayerInGame(playerConfigs[index].PlayerProfil, team, playerConfigs[index].Input.GetComponent<PlayerSetupConfiguration01>());
    }

    public void HoldFunction()
    {
        var playerConfigs = PlayerInTheGame01.Instance.GetPlayerConfigs().ToArray();
        for (int i = 0; i < playerConfigs.Length; i++)
        {
            playerConfigs[i].Input.GetComponent<PlayerSetupConfiguration01>().SetRootMenu(_newRootMenu);
            playerConfigs[i].Input.GetComponent<PlayerSetupConfiguration01>().InitializePlayerInGame(_bulletParent);
            playerConfigs[i].Input.GetComponentInChildren<PlayerHandlerInput01>().InitializePlayer(playerConfigs[i]);
            playerConfigs[i].Input.transform.GetChild(0).transform.position = _playerSpawns[i].position;
            playerConfigs[i].Input.transform.GetChild(0).transform.SetParent(_newParentPlayer);
        }
    }
}
