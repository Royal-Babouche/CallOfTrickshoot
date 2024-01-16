using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSetupChoseTeam : MonoBehaviour
{
    [SerializeField] private PlayerProfil _playerProfil;

    public void SetPlayerProfil(PlayerProfil pp)
    {
        _playerProfil = pp;
    }
}
