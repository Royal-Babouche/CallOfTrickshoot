using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJoinGameManager : MonoBehaviour
{
    [SerializeField] private GameObject _panelIdle, _panelPressAnyButton, _panelP1, _panelP2, _panelP3, _panelP4, _canvasRoot;
    [SerializeField] private Transform _parentPlayer;
    [SerializeField] private bool _ifPlayerTryConnect;
    public void PlayerJoinTheGame(PlayerInput playerInput)
    {
        Debug.Log("Player Joined : " + playerInput.playerIndex);
        playerInput.transform.SetParent(transform);
        playerInput.name = "Player Configuration " + playerInput.playerIndex;

        if (playerInput.playerIndex == 0)
        {
            _panelPressAnyButton.SetActive(false);
            _panelP1.SetActive(true);
            playerInput.GetComponent<PlayerSetupConnexionManager>().Instance(playerInput, _panelP1.GetComponent<PlayerPanel01>());
        }
        if (playerInput.playerIndex == 1)
        {
            _panelP2.SetActive(true);
            playerInput.GetComponent<PlayerSetupConnexionManager>().Instance(playerInput, _panelP2.GetComponent<PlayerPanel0x>());
        }
        if (playerInput.playerIndex == 2)
        {
            _panelP3.SetActive(true);
        }
        if (playerInput.playerIndex == 3)
        {
            _panelP4.SetActive(true);
        }
    }
}
