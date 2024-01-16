using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConfigurationManager01 : MonoBehaviour
{
    [SerializeField] private PlayerProfilManagerData _playerProfilManagerData;

    private void Awake()
    {
        _playerProfilManagerData.Instance();
    }
}
