using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSetupConnexionManager : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private PlayerMenuPanel _playerPanelMenu;
    [SerializeField] private PlayerProfil _playerProfil;

    public void Instance(PlayerInput playerInput, PlayerMenuPanel playerPanelMenu)
    {
        _playerInput = playerInput;
        _playerPanelMenu = playerPanelMenu;
        _playerPanelMenu.SetPlayerSetupConnexion(this);
    }

    public PlayerInput PlayerInput { get => _playerInput; set => _playerInput = value; }
    public PlayerProfil PlayerProfil { get => _playerProfil; set => _playerProfil = value; }
    public PlayerMenuPanel PlayerPanelMenu { get => _playerPanelMenu; set => _playerPanelMenu = value; }
}
