using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PanelPlayerConnexionManager : MonoBehaviour
{
    [SerializeField] private PlayerProfilManagerData _playerProfilManagerData;
    [SerializeField] private GameObject _panelCreate, _buttonBackCreate, _panelConnexion;
    [SerializeField] private TMP_InputField _inputfieldCreate;
    [SerializeField] private TMP_Dropdown _dropdownConnexion;

    private void Start()
    {
        Debug.Log("Nb Profil = " + _playerProfilManagerData.PlayerProfils.Count);
        if(_playerProfilManagerData.PlayerProfils.Count == 0)
        {
            _panelCreate.SetActive(true);
        }
        else
        {
            _panelConnexion.SetActive(true);
        }
    }

    public void SetActivePanelCreate(bool value)
    {
        _panelCreate.SetActive(value);
    }

    public void SetActiveButtonBackCreate(bool value)
    {
        _buttonBackCreate.SetActive(value);
    }
    public void SetActivePanelConnexion(bool value)
    {
        _panelConnexion.SetActive(value);
    }

    public void ClickOnCreate()
    {

    }

    public void ClickOnConnexion()
    {

    }
}
