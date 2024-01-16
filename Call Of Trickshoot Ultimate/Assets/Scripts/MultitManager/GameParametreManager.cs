using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameParametreManager : MonoBehaviour
{
    [SerializeField] private GameParametreData _gameParametreData;
    [SerializeField] private TMP_Dropdown _dropdownMode, _dropdownScore, _dropdownTime, _dropdownManche, _dropdownMap;
    [SerializeField] private Toggle _toggleEsclave;

    public void SetAllParametre()
    {
        _gameParametreData.Mode = _dropdownMode.captionText.text;
        _gameParametreData.Score = _dropdownScore.captionText.text;
        _gameParametreData.Time = _dropdownTime.captionText.text;
        _gameParametreData.Manche = _dropdownManche.captionText.text;
        _gameParametreData.Map = _dropdownMap.captionText.text;
        _gameParametreData.Esclave = _toggleEsclave.isOn;
    }

    public void SetMode()
    {
        _gameParametreData.Mode = _dropdownMode.captionText.text;
    }
    public void SetScore()
    {
        _gameParametreData.Score = _dropdownScore.captionText.text;
    }
    public void SetTime()
    {
        _gameParametreData.Time = _dropdownTime.captionText.text;
    }
    public void SetManche()
    {
        _gameParametreData.Manche = _dropdownManche.captionText.text;
    }
    public void SetMap()
    {
        _gameParametreData.Map = _dropdownMap.captionText.text;
    }
    public void SetEsclave()
    {
        _gameParametreData.Esclave = _toggleEsclave.isOn;
    }
}
