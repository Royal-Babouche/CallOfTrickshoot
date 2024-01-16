using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public abstract class PlayerMenuPanel : MonoBehaviour
{
    [Header("Parametre Principale")]
    [SerializeField] private PlayerProfilManagerData _playerProfilManagerData;
    [SerializeField] private PlayerInTheGameData _playerInTheGameData;
    [SerializeField] private GameParametreData _gameParametreData;
    [SerializeField] private MultiplayerEventSystem _multiplayerEventSystem;
    [SerializeField] private InputSystemUIInputModule _uiInputModule;

    [Header("Parametre Player")]
    [SerializeField] private PlayerSetupConnexionManager _playerSetupConnexionManager;

    [Header("Parametre Panel Connexion")]
    [SerializeField] private GameObject _panelPlayerConnexion;
    [SerializeField] private GameObject _panelCreate;
    [SerializeField] private GameObject _firstSelecedCreate;
    [SerializeField] private GameObject _panelConnexion;
    [SerializeField] private GameObject _firstSelectedConnexion;
    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private TMP_Dropdown _dropdown;

    [Header("Parametre Panel Personnalisation")]
    [SerializeField] private GameObject _panelPersonnalisation;
    [SerializeField] private GameObject _firstSelectedPersonnalisation;
    [SerializeField] private TextMeshProUGUI _buttonReadyText;

    public void SetPlayerSetupConnexion(PlayerSetupConnexionManager playerSetupConnexionManager)
    {
        _playerSetupConnexionManager = playerSetupConnexionManager;
        _title.text = "Player " + (_playerSetupConnexionManager.PlayerInput.playerIndex + 1);
        _playerSetupConnexionManager.PlayerInput.uiInputModule = _uiInputModule;

        if (_playerProfilManagerData.PlayerProfils.Count == 0)
        {
            _panelCreate.SetActive(true);
            _firstSelecedCreate.SetActive(false);
        }
        else
        {
            _panelConnexion.SetActive(true);
            ActualiseDropdownConnexion();
            _multiplayerEventSystem.SetSelectedGameObject(_firstSelectedConnexion);
        }
    }

    public void CreateProfil(GameObject nextSelected)
    {
        //Debug.Log(_inputField.text + " / " + _inputField.textComponent);
        string newPseudo = _inputField.text;
        if (newPseudo.Length > 4 && newPseudo.Length < 12)
        {
            Debug.Log("_inputField.text.Length > 4 && _inputField.text.Length < 12 : Can Add Profil");
            if (!_playerProfilManagerData.VerifNewPseudo(newPseudo))
            {
                _playerProfilManagerData.AddNewProfil(newPseudo);
                if (!_firstSelecedCreate.activeSelf)
                {
                    _firstSelecedCreate.SetActive(true);
                }
                _panelCreate.SetActive(false);
                _panelConnexion.SetActive(true);
                SetSelectedGameObj(nextSelected);
                ActualiseDropdownConnexion();
            }
        }
        else
        {
            Debug.Log("_inputField.text.Length >= 12 : Can't Add Profil");
        }
    }

    public void ActualiseDropdownConnexion()
    {
        _dropdown.ClearOptions();
        _dropdown.AddOptions(_playerProfilManagerData.GetAllPseudoIsNotConnected());
    }

    public void ClickOnCreateConnexion(GameObject nextSelected)
    {
        _panelConnexion.SetActive(false);
        _panelCreate.SetActive(true);
        SetSelectedGameObj(nextSelected);
    }

    public void ClickOnConnexionCreate(GameObject nextSelected)
    {
        _panelCreate.SetActive(false);
        _panelConnexion.SetActive(true);
        SetSelectedGameObj(nextSelected);
    }

    public virtual void ClickOnConnexion()
    {
        _playerSetupConnexionManager.PlayerProfil = _playerProfilManagerData.ConnexionToProfil(_dropdown.captionText.text);
        _playerInTheGameData.AddPlayer(_playerSetupConnexionManager.PlayerProfil);
        _panelPlayerConnexion.SetActive(false);
    }

    public void SetSelectedGameObj(GameObject nextSelected)
    {
        _multiplayerEventSystem.SetSelectedGameObject(nextSelected);
    }

    public void SetFirstSelectPersonnalisation()
    {
        _multiplayerEventSystem.SetSelectedGameObject(_firstSelectedPersonnalisation);
    }

    public void ClickOnReadyPlayer()
    {
        _playerSetupConnexionManager.PlayerProfil.IsReady = !_playerSetupConnexionManager.PlayerProfil.IsReady;
        if(_playerSetupConnexionManager.PlayerProfil.IsReady)
        {
            _buttonReadyText.text = "Is Ready";
        }
        else
        {
            _buttonReadyText.text = "Ready";
        }

        if(_playerInTheGameData.IfAllIsReady())
        {
            SceneManager.LoadScene(_gameParametreData.Map);
        }
    }

    public GameObject PanelPersonnalisation { get => _panelPersonnalisation; set => _panelPersonnalisation = value; }
    public PlayerInTheGameData PlayerInTheGameData { get => _playerInTheGameData; set => _playerInTheGameData = value; }
    public GameObject FirstSelectedPersonnalisation { get => _firstSelectedPersonnalisation; set => _firstSelectedPersonnalisation = value; }
    public PlayerSetupConnexionManager PlayerSetupConnexionManager { get => _playerSetupConnexionManager; set => _playerSetupConnexionManager = value; }
    public GameParametreData GameParametreData { get => _gameParametreData; set => _gameParametreData = value; }
}
