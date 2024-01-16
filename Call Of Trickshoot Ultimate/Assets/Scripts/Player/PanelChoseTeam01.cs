using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.UI;

public class PanelChoseTeam01 : MonoBehaviour
{
    [SerializeField] private LevelInitialize01 _levelInitialize01;
    [SerializeField] private GameObject _panelNoTeam, _firstGoNoTeam, _panelTeam, _firstGoTeam;
    [SerializeField] private PlayerConfiguration _playerConfiguration;
    [SerializeField] private MultiplayerEventSystem _multiplayerEventSystem;
    [SerializeField] private InputSystemUIInputModule _inputSystemUI;

    public void SetPlayer(LevelInitialize01 levelInitialize01, PlayerConfiguration pc, bool boolTeam)
    {
        _levelInitialize01 = levelInitialize01;
        _playerConfiguration = pc;
        _playerConfiguration.Input.uiInputModule = _inputSystemUI;
        if(boolTeam)
        {
            _panelTeam.SetActive(true);
            _multiplayerEventSystem.SetSelectedGameObject(_firstGoTeam);
        }
        else
        {
            _panelNoTeam.SetActive(true);
            _multiplayerEventSystem.SetSelectedGameObject(_firstGoNoTeam);
        }
    }

    public void ClickOnNoTeamTeam()
    {
        Debug.Log("Click On No Team Team");
        _levelInitialize01.SpwanPlayer(_playerConfiguration.PlayerIndex, "NoTeam");
        gameObject.SetActive(false);
    }

    public void ClickOnTeamTeam01()
    {
        Debug.Log("Click On No Team 01");
        _levelInitialize01.SpwanPlayer(_playerConfiguration.PlayerIndex, "Team01");
        gameObject.SetActive(false);
    }

    public void ClickOnTeamTeam02()
    {
        Debug.Log("Click On No Team 02");
        _levelInitialize01.SpwanPlayer(_playerConfiguration.PlayerIndex, "Team02");
        gameObject.SetActive(false);
    }

    public void ClickOnSpectateur()
    {
        Debug.Log("Click On Spectateur");
    }
}
