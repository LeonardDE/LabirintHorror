using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Interective _playerInterective;
    public GameObject _pressE;

    public GameObject _textBongTime;
    public BongController _bongController;
    
    // Переменные для отображения уведомлений состояний
    public BeastController _beastController;
    public GameObject _textBeastHunting;
    public GameObject _textBeastRelaxing;

    private float _timeRollBack = 0;
    private int _lastStatus = 0;
    
    private void Update()
    {
        PressE();
        TimeBong();
        BeastStatus();
    }
    
    public void PressE()
    {
        _pressE.SetActive(_playerInterective.ExitButtonOnScreen);
    }

    private void TimeBong()
    {
        _textBongTime.GetComponent<Text>().text = Convert.ToString(Mathf.Floor(_bongController._rollBackTime));
    }

    private void BeastStatus()
    {
        if (_lastStatus != _beastController.ZeroOne)
        {
            _timeRollBack = 3;
            _lastStatus = _beastController.ZeroOne;
            _textBeastHunting.SetActive(_lastStatus == 1);
            _textBeastRelaxing.SetActive(_lastStatus == 0);
        }

        if (_timeRollBack > 0)
        {
            _timeRollBack -= Time.deltaTime;
        }
        else if (_timeRollBack != 0)
        {
            _timeRollBack = 0;
            _textBeastHunting.SetActive(false);
            _textBeastRelaxing.SetActive(false);
        }
    }
}
