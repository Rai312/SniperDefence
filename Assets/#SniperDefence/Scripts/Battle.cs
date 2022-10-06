using System;
using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour
{
    [SerializeField] private Team _teamDefender;
    [SerializeField] private Team _teamEnemy;

    //[SerializeField] private Text _drawMessage;
    //[SerializeField] private Text _firstTeamWinText;
    //[SerializeField] private Text _secondTeamWinText;

    private void Awake()
    {
        Initialization();
    }

    private void OnDestroy()
    {
        foreach (var unit in _teamDefender.Units)
        {
            unit.Died -= CheckWin;
        }

        foreach (var unit in _teamEnemy.Units)
        {
            unit.Died -= CheckWin;
        }
    }

    //public void StartBattle()
    //{
    //    foreach (var unit in _teamDefender.Units)
    //    {
    //        unit.StartBattle();
    //    }

    //    foreach (var unit in _teamEnemy.Units)
    //    {
    //        unit.StartBattle();
    //    }
    //}

    public void Initialization()
    {
        foreach (var unit in _teamDefender.Units)
        {
            unit.Initialize(_teamEnemy.Units);
            unit.Died += CheckWin;
        }

        foreach (var unit in _teamEnemy.Units)
        {
            unit.Initialize(_teamDefender.Units);
            unit.Died += CheckWin;
        }
    }

    private void CheckWin()
    {
        bool firstTeamResult = _teamDefender.CheckLose();
        bool secondTeamResult = _teamEnemy.CheckLose();

        //if (firstTeamResult && secondTeamResult)
        //{
        //    _drawMessage.gameObject.SetActive(true);
        //}
        //else
        //{
        //    if (firstTeamResult)
        //        _secondTeamWinText.gameObject.SetActive(true);
        //    if (secondTeamResult)
        //        _firstTeamWinText.gameObject.SetActive(true);
        //}
    }
}
