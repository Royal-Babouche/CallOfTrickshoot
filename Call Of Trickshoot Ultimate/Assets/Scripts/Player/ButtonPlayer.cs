using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

[System.Serializable]
public class ButtonPlayer
{
    [SerializeField] private string _nameButton;
    [SerializeField] private bool _oneTape, _desaOneTape, _doubleTape;
    [SerializeField] private float _value, _timeDoubleTape, _timeDoubleTapeMax;

    public void GetValue(CallbackContext obj)
    {
        if (obj.action.name == _nameButton)
        {
            _value = obj.ReadValue<float>();
        }
        if (_value == 1 && !_oneTape && !_desaOneTape)
        {
            Debug.Log(_nameButton + " : One Tape");
            _oneTape = true;
        }
        if (_value == 1 && _oneTape && _desaOneTape && !_doubleTape)
        {
            Debug.Log(_nameButton + " : Double Tape");
            _doubleTape = true;
        }
        if ((_value == 0 && _oneTape && _desaOneTape && _doubleTape) || _value == 0 && !_oneTape && !_desaOneTape && _doubleTape)
        {
            _doubleTape = false;
        }
    }

    public void GestionButton()
    {
        if (_value == 0 && _oneTape && !_desaOneTape)
        {
            _desaOneTape = true;
        }
        if (_value == 0 && _oneTape && _desaOneTape && _doubleTape)
        {
            DesactiveOneTape();
            DesaciveDoubleTape();
        }

        GestionTime();
    }

    public void GestionTime()
    {
        if (_oneTape)
        {
            _timeDoubleTape -= Time.deltaTime;
        }

        if (_timeDoubleTape <= 0)
        {
            DesactiveOneTape();
        }
    }

    private void DesactiveOneTape()
    {
        _timeDoubleTape = _timeDoubleTapeMax;
        _oneTape = false;
        _desaOneTape = false;
    }

    private void DesaciveDoubleTape()
    {
        _timeDoubleTape = _timeDoubleTapeMax;
        _doubleTape = false;
    }

    public bool IfOneOrDouble()
    {
        bool verif = false;
        if(_oneTape || _doubleTape)
        {
            verif = true;
        }
        return verif;
    }

    public bool OneTape { get => _oneTape; set => _oneTape = value; }
    public bool DesaOneTape { get => _desaOneTape; set => _desaOneTape = value; }
    public bool DoubleTape { get => _doubleTape; set => _doubleTape = value; }
}
