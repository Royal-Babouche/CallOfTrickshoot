using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class PlayerSetupConfiguration01 : MonoBehaviour
{
    [SerializeField] private GameObject _playerSetupMenuPrefab, _playerSetupMenuPrefabP1, _playerSetupMenuPrefabPx, _panelReticule, _player, _esclave;
    [SerializeField] private Transform _rootMenu;
    [SerializeField] private PlayerInput _input;
    [SerializeField] private PlayerProfilInGame _playerProfilInGame;
    [SerializeField] private PlayerShoot01 _playerShoot01;
    [SerializeField] private PlayerGroundCheck _playerGroundCheck;

    [SerializeField] private PlayerProfil _playerProfil;
    [SerializeField] private Weapon _weapon1, _weapon2;


    public void InitializePlayerConfiguration(Transform rootmenu)
    {
        _rootMenu = rootmenu;
        GameObject cloneMenu = Instantiate(_playerSetupMenuPrefab, _rootMenu.transform);
        _input.uiInputModule = cloneMenu.GetComponentInChildren<InputSystemUIInputModule>();
        cloneMenu.GetComponent<PlayerSetupMenuControl01>().SetPlayerIndex(_input.playerIndex);
    }

    public void InitializePlayerConfiguration(Transform rootmenu, PlayerInput pi)
    {
        _rootMenu = rootmenu;
        if (pi.playerIndex == 0)
        {
            GameObject cloneMenu = Instantiate(_playerSetupMenuPrefabP1, _rootMenu.transform);
            _input.uiInputModule = cloneMenu.GetComponentInChildren<InputSystemUIInputModule>();
            cloneMenu.GetComponent<PlayerSetupMenuControl01>().SetPlayerIndex(_input.playerIndex);
        }
        else
        {
            GameObject cloneMenu = Instantiate(_playerSetupMenuPrefabPx, _rootMenu.transform);
            _input.uiInputModule = cloneMenu.GetComponentInChildren<InputSystemUIInputModule>();
            cloneMenu.GetComponent<PlayerSetupMenuControl01>().SetPlayerIndex(_input.playerIndex);
        }
    }

    public void InitializePlayerConfiguration(Transform rootmenu, PlayerConfiguration pc)
    {
        Debug.Log("InitializePlayerConfiguration(Transform rootmenu, PlayerConfiguration pc)");
        _player.SetActive(false);
        _esclave.SetActive(false);
        _rootMenu = rootmenu;
        if (pc.PlayerIndex == 0)
        {
            GameObject cloneMenu = Instantiate(_playerSetupMenuPrefabP1, _rootMenu.transform);
            _input.uiInputModule = cloneMenu.GetComponentInChildren<InputSystemUIInputModule>();
            cloneMenu.GetComponent<PanelPlayerSetup>().SetPlayerIndex(pc, this);
        }
        else
        {
            GameObject cloneMenu = Instantiate(_playerSetupMenuPrefabPx, _rootMenu.transform);
            _input.uiInputModule = cloneMenu.GetComponentInChildren<InputSystemUIInputModule>();
            cloneMenu.GetComponent<PanelPlayerSetup>().SetPlayerIndex(pc, this);
        }
        _playerProfil = pc.PlayerProfil;
    }

    public void InitializePlayerInGame(Transform bulletParent)
    {
        Debug.Log("InitializePlayerInGame(Transform bulletParent) // Ici j'ai le Player Profil In Game a mettre");
        _player.SetActive(true);
        _playerShoot01.SetParent(bulletParent);
        _panelReticule.SetActive(true);
    }
    public void SetRootMenu(Transform rootMenu)
    {
        _rootMenu = rootMenu;
    }
    public void SetProfilPlayer(PlayerProfil pp)
    {
        _playerProfil = pp;
        _player.name = "Player_" + _playerProfil.Pseudo;
        _playerGroundCheck.PlayerName = _player.name;
    }

    public void SetPlayerInGame(PlayerInGame pig)
    {
        _playerProfilInGame.SetPlayerInGame(pig);
        _weapon1.SetPlayerInGame(pig);
        _weapon2.SetPlayerInGame(pig);
    }

    public PlayerProfilInGame PlayerProfilInGame { get => _playerProfilInGame; set => _playerProfilInGame = value; }
}
