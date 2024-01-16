using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PanelSetupConnexion01 : MonoBehaviour
{
    [SerializeField] private PlayerProfilManagerData _playerProfilManagerData;
    [SerializeField] private GameObject _panelCreate, _firstGoCreate, _panelConnexion, _firstGoConnexion, _buttonToConnexion;
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private TMP_Dropdown _dropdown;

    public bool Instance()
    {
        bool verif = false;
        if (_playerProfilManagerData.PlayerProfils.Count == 0)
        {
            _panelCreate.SetActive(true);
            GestionButtonToConnexion();
        }
        else
        {
            _panelConnexion.SetActive(true);
            verif = true;
        }
        return verif;
    }

    public bool CreateProfil()
    {
        bool verif = false;
        string newPseudo = _inputField.text;
        if (newPseudo.Length > 3 && newPseudo.Length < 12)
        {
            _playerProfilManagerData.AddNewProfil(newPseudo);
            verif = true;
        }
        return verif;
    }

    public PlayerProfil ConnexionToProfil()
    {
        return _playerProfilManagerData.ConnexionToProfil(_dropdown.captionText.text);
    }

    public void ActualiseListe()
    {
        _dropdown.ClearOptions();
        _dropdown.AddOptions(_playerProfilManagerData.GetAllPseudoIsNotConnected());
    }

    public void SetActivePanelCreate(bool value)
    {
        _panelCreate.SetActive(value);
    }
    public void SetActivePanelConnexion(bool value)
    {
        _panelConnexion.SetActive(value);
    }

    public void SetActiveThis(bool value)
    {
        gameObject.SetActive(value);
    }

    public void ClickOnToCreate()
    {
        _panelConnexion.SetActive(false);
        _panelCreate.SetActive(true);
        GestionButtonToConnexion();
    }

    public void ClickOnToConnexion()
    {
        _panelCreate.SetActive(false);
        _panelConnexion.SetActive(true);
    }

    public void GestionButtonToConnexion()
    {
        Debug.Log("ClickOnToConnexion");
        if (_playerProfilManagerData.PlayerProfils.Count == 0)
        {
            _buttonToConnexion.SetActive(false);
        }
        else
        {
            if (!_buttonToConnexion.activeSelf)
            {
                _buttonToConnexion.SetActive(true);
            }
        }
    }

    public GameObject FirstGoCreate { get => _firstGoCreate; set => _firstGoCreate = value; }
    public GameObject FirstGoConnexion { get => _firstGoConnexion; set => _firstGoConnexion = value; }
}
