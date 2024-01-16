using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerPanel01 : PlayerMenuPanel
{
    [Header("Parametre Menu")]
    [SerializeField] private GameObject _panelMainMenu;
    [SerializeField] private TextMeshProUGUI _textTitle;
    [SerializeField] private GameObject _panelMenu;
    [SerializeField] private GameObject _firstSelecedMenu;
    [SerializeField] private GameObject _panelPlay;
    [SerializeField] private GameObject _panelGameParametre;
    [SerializeField] private GameObject _firstSelecedGameParametre;
    [SerializeField] private GameObject _firstSelecedPersonnalisation;
    [SerializeField] private GameObject _panelOption;
    [SerializeField] private GameObject _firstSelecedOption;

    [Header("Parametre Panel Perso 0x")]
    [SerializeField] private GameObject _panelPerso02;
    [SerializeField] private GameObject _panelPerso03;
    [SerializeField] private GameObject _panelPerso04;

    [Header("Parametre Data")]
    [SerializeField] private GameParametreManager _gameParametreManager;

    public override void ClickOnConnexion()
    {
        base.ClickOnConnexion();
        _panelMainMenu.SetActive(true);
        SetSelectedGameObj(_firstSelecedMenu);
        _textTitle.text = PlayerSetupConnexionManager.PlayerProfil.Pseudo;
        PlayerInTheGameData.InMenu = true;
    }

    public void ClickOnPlay()
    {
        _panelMenu.SetActive(false);
        _panelPlay.SetActive(true);
        SetSelectedGameObj(_firstSelecedGameParametre);
    }

    public void ClickOnNextGameParametre()
    {
        _gameParametreManager.SetAllParametre();
        _panelGameParametre.SetActive(false);
        PanelPersonnalisation.SetActive(true);
        SetSelectedGameObj(_firstSelecedPersonnalisation);
        PlayerInTheGameData.InPersonnalisation = true;
        if(PlayerInTheGameData.PlayerProfils.Count >= 2)
        {
            _panelPerso02.SetActive(true);
            _panelPerso02.GetComponentInParent<PlayerPanel0x>().SetFirstSelectPersonnalisation();
            if (PlayerInTheGameData.PlayerProfils.Count >= 3)
            {
                _panelPerso03.SetActive(true);
                _panelPerso03.GetComponentInParent<PlayerPanel0x>().SetFirstSelectPersonnalisation();
                if (PlayerInTheGameData.PlayerProfils.Count >= 4)
                {
                    _panelPerso04.SetActive(true);
                    _panelPerso04.GetComponentInParent<PlayerPanel0x>().SetFirstSelectPersonnalisation();
                }
            }
        }
    }

    public void ClickOnBackPersonnalisation()
    {
        PanelPersonnalisation.SetActive(false);
        _panelGameParametre.SetActive(true);
        SetSelectedGameObj(_firstSelecedGameParametre);
        PlayerInTheGameData.InPersonnalisation = false;
        if (PlayerInTheGameData.PlayerProfils.Count >= 2)
        {
            _panelPerso02.SetActive(false);
            if (PlayerInTheGameData.PlayerProfils.Count >= 3)
            {
                _panelPerso03.SetActive(false);
                if (PlayerInTheGameData.PlayerProfils.Count >= 4)
                {
                    _panelPerso04.SetActive(false);
                }
            }
        }
        //PlayerInTheGameData.SetReadyIsNullForAll();
    }

    public void ClickOnBackGameParametre()
    {
        _panelPlay.SetActive(false);
        _panelMenu.SetActive(true);
        SetSelectedGameObj(_firstSelecedMenu);
    }


}
