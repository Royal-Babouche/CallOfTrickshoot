using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu]
public class PlayerProfilManagerData : ScriptableObject
{
    [SerializeField] private int _sizeMax;
    [SerializeField] private List<PlayerProfil> _playerProfils;

    public void Instance()
    {
        for (int i = 0; i < _playerProfils.Count; i++)
        {
            if (_playerProfils[i].IsConnected)
            {
                _playerProfils[i].Instance();
            }
        }
    }

    public bool VerifNewPseudo(string pseudo)
    {
        bool verifPseudo = false;

        for (int i = 0; i < _playerProfils.Count; i++)
        {
            if (pseudo == _playerProfils[i].Pseudo)
            {
                Debug.Log(pseudo + " == _playerProfils[" + i + "].Pseudo (" + _playerProfils[i].Pseudo + ")");
                verifPseudo = true;
            }
        }

        return verifPseudo;
    }

    public void AddNewProfil(string pseudo)
    {
        if (_playerProfils.Count < _sizeMax)
        {
            Debug.Log("_playerProfils.Count < _sizeMax : Can Add Profil");
            PlayerProfil newPP = new PlayerProfil(pseudo);
            _playerProfils.Add(newPP);

        }
        else
        {
            Debug.Log("_playerProfils.Count >= _sizeMax : Can't Add Profil");
        }
    }

    public void RemoveProfil(string pseudo)
    {
        bool verifPseudo = false;
        int indexToRemove = 0;
        for (int i = 0; i < _playerProfils.Count; i++)
        {
            if (pseudo == _playerProfils[i].Pseudo)
            {
                Debug.Log(pseudo + " == _playerProfils[" + i + "].Pseudo (" + _playerProfils[i].Pseudo + ")");
                verifPseudo = true;
                indexToRemove = i;
            }
        }

        if (verifPseudo)
        {
            _playerProfils.RemoveAt(indexToRemove);
        }
    }

    public List<string> GetAllPseudo()
    {
        List<string> pseudoList = new List<string>();

        for (int i = 0; i < _playerProfils.Count; i++)
        {
            pseudoList.Add(_playerProfils[i].Pseudo);
        }

        return pseudoList;
    }

    public List<string> GetAllPseudoIsNotConnected()
    {
        List<string> pseudoList = new List<string>();

        for (int i = 0; i < _playerProfils.Count; i++)
        {
            if (!_playerProfils[i].IsConnected)
            {
                pseudoList.Add(_playerProfils[i].Pseudo);
            }
        }

        return pseudoList;
    }

    public PlayerProfil ConnexionToProfil(string pseudo)
    {
        PlayerProfil ppReturn = new PlayerProfil();
        for (int i = 0; i < _playerProfils.Count; i++)
        {
            if(pseudo == _playerProfils[i].Pseudo)
            {
                ppReturn = _playerProfils[i];
                ppReturn.SetIsConnected(true);
            }
        }
        return ppReturn;
    }

    public List<PlayerProfil> PlayerProfils { get => _playerProfils; set => _playerProfils = value; }
}
