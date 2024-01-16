using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;

public class PanelPlayerSetup : MonoBehaviour
{
    [SerializeField] private MultiplayerEventSystem _multiplayerEventSystem;
    [SerializeField] private PanelSetupConnexion01 _panelSetupConnexion01;
    [SerializeField] private PlayerSetupConfiguration01 _playerSetupConfiguration01;

    [SerializeField] private int _playerIndex;
    [SerializeField] private PlayerConfiguration _playerConfig;
    [SerializeField] private TextMeshProUGUI _titleTextMain, _readyButtonTexte;

    private float ignoreInputTime = 1.5f;
    private bool inputEnable;

    public PlayerConfiguration PlayerConfig { get => _playerConfig; set => _playerConfig = value; }

    private void Update()
    {
        if (Time.time > ignoreInputTime)
        {
            inputEnable = true;
        }
    }

    public virtual void SetPlayerIndex(PlayerConfiguration pc, PlayerSetupConfiguration01 psc)
    {
        _playerConfig = pc;
        _playerIndex = _playerConfig.PlayerIndex;
        _titleTextMain.SetText("Player " + (_playerIndex + 1).ToString());
        ignoreInputTime += Time.time;

        if(_panelSetupConnexion01.Instance())
        {
            SetSelectedObject(_panelSetupConnexion01.FirstGoConnexion);
            _panelSetupConnexion01.ActualiseListe();
        }
        else
        {
            SetSelectedObject(_panelSetupConnexion01.FirstGoCreate);
        }

        _playerSetupConfiguration01 = psc;
    }

    public void ClickOnCreate()
    {
        if(_panelSetupConnexion01.CreateProfil())
        {
            _panelSetupConnexion01.SetActivePanelCreate(false);
            _panelSetupConnexion01.SetActivePanelConnexion(true);
            SetSelectedObject(_panelSetupConnexion01.FirstGoConnexion);
            _panelSetupConnexion01.ActualiseListe();
        }
    }

    public virtual void ClickOnConnexion()
    {
        Debug.Log("ClickOnConnexion");
        _playerConfig.PlayerProfil = _panelSetupConnexion01.ConnexionToProfil();
        _playerSetupConfiguration01.SetProfilPlayer(_playerConfig.PlayerProfil);
        _panelSetupConnexion01.SetActiveThis(false);
    }

    public virtual void ClickOnToCreate()
    {
        _panelSetupConnexion01.ClickOnToCreate();
        SetSelectedObject(_panelSetupConnexion01.FirstGoCreate);
    }

    public virtual void ClickOnToConnexion()
    {
        _panelSetupConnexion01.ClickOnToConnexion();
        SetSelectedObject(_panelSetupConnexion01.FirstGoConnexion);
    }

    public virtual void ClickOnReady()
    {
        if (!inputEnable) { return; }

        if (PlayerInTheGame01.Instance.ReadyPlayer(_playerIndex))
        {
            _readyButtonTexte.text = "Is Ready";
        }
        else
        {
            _readyButtonTexte.text = "Ready";
        }
    }

    public void SetSelectedObject(GameObject go)
    {
        _multiplayerEventSystem.SetSelectedGameObject(go);
    }
}
