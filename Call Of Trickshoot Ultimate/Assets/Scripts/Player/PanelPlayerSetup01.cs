using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelPlayerSetup01 : PanelPlayerSetup
{
    [SerializeField] private GameParametreData _gameParametreData;

    [SerializeField] private GameObject _panelMenuMain, _panelMenu, _firstGoMenu, _panelPlay, _panelGameParametre, _firstGoGameParametre, _panelPersonnalisation, _firstGoPersonnalisation, _panelOption, _firstGoOption;

    [SerializeField] private TextMeshProUGUI _titleMenuMain;

    [SerializeField] private TMP_Dropdown _dropdownMode, _dropdownScore, _dropdownTime, _dropdownManche, _dropdownMap;
    [SerializeField] private Toggle _toggleEsclave, _toglleTraversInfini;

    public override void ClickOnConnexion()
    {
        Debug.Log("Override ClickOnConnexion");
        base.ClickOnConnexion();
        _panelMenuMain.SetActive(true);
        SetSelectedObject(_firstGoMenu);
        _titleMenuMain.text = PlayerConfig.PlayerProfil.Pseudo;
    }

    public void ClickOnPlay()
    {
        _panelMenu.SetActive(false);
        _panelPlay.SetActive(true);
        SetSelectedObject(_firstGoGameParametre);
    }

    public void ClickOnNextToPersonnalisation()
    {
        _panelGameParametre.SetActive(false);
        _panelPersonnalisation.SetActive(true);
        SetSelectedObject(_firstGoPersonnalisation);
        _gameParametreData.ModifieAllValue(_dropdownMode.captionText.text, _dropdownScore.captionText.text, _dropdownTime.captionText.text, _dropdownManche.captionText.text, _dropdownMap.captionText.text, _toggleEsclave.isOn, _toglleTraversInfini.isOn);
    }

    public void ClickOnBackToGameParametre()
    {
        _panelPersonnalisation.SetActive(false);
        _panelGameParametre.SetActive(true);
        SetSelectedObject(_firstGoGameParametre);
    }

    public void ClickOnBackMenu(GameObject panoToDesactive)
    {
        panoToDesactive.SetActive(false);
        _panelMenu.SetActive(true);
        SetSelectedObject(_firstGoMenu);
    }

    public void ClickOnOption()
    {
        Debug.Log("ClickOnOption");
    }

    public void ClickOnQuit()
    {
        Debug.Log("ClickOnQuit");
    }
}
