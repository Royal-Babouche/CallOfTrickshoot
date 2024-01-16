using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPanel0x : PlayerMenuPanel
{
    public override void ClickOnConnexion()
    {
        base.ClickOnConnexion();
        if(PlayerInTheGameData.InPersonnalisation)
        {
            PanelPersonnalisation.SetActive(true);
            SetSelectedGameObj(FirstSelectedPersonnalisation);
        }
        Debug.Log("ClickOnConnexion");
    }
}
