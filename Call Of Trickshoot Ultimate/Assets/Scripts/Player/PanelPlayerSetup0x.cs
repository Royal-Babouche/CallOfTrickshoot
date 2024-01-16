using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelPlayerSetup0x : PanelPlayerSetup
{
    [SerializeField] private GameObject _panelPersonnalisation, _firstGoPersonnalisation;
    public override void ClickOnConnexion()
    {
        base.ClickOnConnexion();
        _panelPersonnalisation.SetActive(true);
        SetSelectedObject(_firstGoPersonnalisation);
    }
}
